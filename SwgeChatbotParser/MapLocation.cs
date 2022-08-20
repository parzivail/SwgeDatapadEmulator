namespace SwgeChatbotParser;

public record MapLocation(string Filename, string Name)
{
	public static readonly MapLocation Dlr = new("dlr", "Disneyland");
	public static readonly MapLocation SwgsDeck4A = new("swgs_deck4a", "SWGS Deck 4A");
	public static readonly MapLocation SwgsDeck4F = new("swgs_deck4f", "SWGS Deck 4F");
	public static readonly MapLocation SwgsDeck5 = new("swgs_deck5", "SWGS Deck 5");
	public static readonly MapLocation SwgsDeck6 = new("swgs_deck6", "SWGS Deck 6");
	public static readonly MapLocation SwgsDeck7 = new("swgs_deck7", "SWGS Deck 7");
	public static readonly MapLocation Wdw = new("wdw", "Walt Disney World");
	
	public static readonly MapLocation[] Values = { Dlr, SwgsDeck4A, SwgsDeck4F, SwgsDeck5, SwgsDeck6, SwgsDeck7, Wdw };
}