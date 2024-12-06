using kosar2004;
using MySql.Data.MySqlClient;

List<Match> matches = new List<Match>();
try
{
    MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=kosarlabda");
    mySqlConnection.Open();
    MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
    mySqlCommand.CommandText = "SELECT * FROM eredmenyek";
    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
    while (mySqlDataReader.Read())
    {
        matches.Add(new Match(mySqlDataReader.GetString("hazai"), mySqlDataReader.GetString("idegen"), mySqlDataReader.GetInt32("hazai_pont"), mySqlDataReader.GetInt32("idegen_pont"), mySqlDataReader.GetString("helyszin"), DateTime.Parse(mySqlDataReader.GetString("idopont"))));
    }
    mySqlDataReader.Close();
    mySqlConnection.Close();
}
catch (MySqlException e)
{
	Console.WriteLine(e.Message);
}

Console.WriteLine("----- 3.Feladat -----");
int homeCount = 0;
int guestCount = 0;
for (int i  = 0; i < matches.Count; i++)
{
	if (matches[i].Home == "Real Madrid")
	{
		homeCount++;
	}
	else if (matches[i].Guest == "Real Madrid")
	{
		guestCount++;
	}
}
Console.WriteLine("Real Madrid: \n Hazai: " + homeCount + "\n Idegen: " + guestCount);

Console.WriteLine("----- 4.Feladat -----");
bool draw = false;
for (int i = 0; i < matches.Count; i++) 
{ 
	if (matches[i].HomePoints == matches[i].GuestPoints)
	{
		draw = true;
	}
}
Console.WriteLine("Volt döntetlen mérközés? " + (draw ? "Igen" : "Nem"));

Console.WriteLine("----- 5.Feladat -----");
string name = "";
for (int i = 0; i < matches.Count; i++)
{
	if (matches[i].Home.Contains("Barcelona"))
	{
		name = matches[i].Home;
	}
}
Console.WriteLine("barceloniai csapat neve: " + (name != "" ? name : "Nincs"));

Console.WriteLine("----- 6.Feladat -----");
List<Match> matchesOnSpecificDate = new List<Match>();
for (int i = 0; i < matches.Count; i++)
{
	if (matches[i].Date == new DateTime(2004, 11, 21))
	{
		matchesOnSpecificDate.Add(matches[i]);
	}
}
for (int i = 0; i < matchesOnSpecificDate.Count; i++)
{
	Console.WriteLine(matchesOnSpecificDate[i].Home + "-" + matchesOnSpecificDate[i].Guest + " (" + matchesOnSpecificDate[i].HomePoints + ":" + matchesOnSpecificDate[i].GuestPoints + ")");
}

Console.WriteLine("----- 7.Feladat -----");
Dictionary<string, int> stadiums = new Dictionary<string, int>();
for (int i = 0; i < matches.Count; i++)
{
	if (!stadiums.ContainsKey(matches[i].Location))
	{
		stadiums.Add(matches[i].Location, 1);
	}
	else if (stadiums.ContainsKey(matches[i].Location))
	{
		stadiums[matches[i].Location] += 1;
	}
}
foreach (KeyValuePair<string, int> stadium in stadiums)
{
	if (stadium.Value > 20)
	{
		Console.WriteLine(stadium.Key + ": " + stadium.Value);
	}
}