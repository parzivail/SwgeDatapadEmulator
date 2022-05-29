# SwgeDatapadEmulator
Managed package that emulates the Disney PlayAPI backend used by the Play Disney Parks (Android) app to allow the Star Wars Datapad to both run in a browser and accept injected man-in-the-middle state data over a websocket

## `SwgeDatapadEmulator` project

Inject the following JavaScript snippit into the Datapad frontend to allow the API commands to be handled over the websocket:

```javascript
const _interopSocket = new WebSocket('ws://localhost:7777');

_interopSocket.addEventListener('message', function (message) {
	PlayAPI.handlePromiseReponse(message.data)
});

window.Android = {
	postMessage: function(message) {
		_interopSocket.send(message);
	}
};
```

The app can also be repacked with a slightly different injected script to allow the app running on actual hardware to log all interactions between PlayAPI and the native application (useful for getting sample data at parks, for beacons, etc)

**Important**: the WebSocket implementation used by the WebView hosting the Datapad can only make secure WebSocket connections. This requires a domain name and valid SSL certificate on the listening server.

```javascript
const _interopSocket = new WebSocket('wss://YOUR_DOMAIN_NAME.com:7777');
var _isConnected = false;

_interopSocket.addEventListener('open', function (event) {
	_isConnected = true;
    _interopSocket.send(JSON.stringify({
		type: "CONNECT",
		timestamp: new Date().toISOString()
	}))
});

window.addEventListener('error', (event) => {
	if (_isConnected)
		_interopSocket.send(JSON.stringify({
			type: "WINDOW_ERROR",
			timestamp: new Date().toISOString(),
			payload: event
		}))
});

try {
	var original_sendCommand = _PlayAPI._sendCommand;

	_PlayAPI._sendCommand = function(cmdObject) {
		if (_isConnected)
			_interopSocket.send(JSON.stringify({
				type: "COMMAND_JS_TO_NATIVE",
				timestamp: new Date().toISOString(),
				payload: cmdObject
			}))
	
		original_sendCommand.call(_PlayAPI, cmdObject);
	};
	
	var original_handlePromiseReponse = _PlayAPI._handlePromiseReponse;
	
	_PlayAPI._handlePromiseReponse = function(res) {
		var response = _PlayAPI._parseIfNecessary(res);
		if (_isConnected)
			_interopSocket.send(JSON.stringify({
				type: "COMMAND_NATIVE_TO_JS",
				timestamp: new Date().toISOString(),
				payload: response
			}))
	
		original_handlePromiseReponse.call(_PlayAPI, res);
	};
	
	var original_nativeCallback = PlayAPI.nativeCallback;
	
	PlayAPI.nativeCallback = function(res) {
		var response = _PlayAPI._parseIfNecessary(res);
		if (_isConnected)
			_interopSocket.send(JSON.stringify({
				type: "COMMAND_NATIVE_CALLBACK",
				timestamp: new Date().toISOString(),
				payload: response
			}))
	
		original_nativeCallback.call(PlayAPI, res);
	}
}
catch (err) {
	if (_isConnected)
			_interopSocket.send(JSON.stringify({
			type: "INIT_ERROR",
			timestamp: new Date().toISOString(),
			payload: err
		}))
}
```

## `SwgeChatbotParser` project

Work-in-progress attempt to emulate the data flow of missions and chat steps to generate a dialogue tree that details all of the possible interactions, items, and installations/beacons/barcodes at Galaxy's Edge and Galactic Starcruiser.
