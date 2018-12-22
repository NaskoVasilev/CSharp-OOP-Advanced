using System.Linq;
using System.Text;

public class Engine
{
    private GameController gameController;
    private IReader reader;
    private IWriter writer;

    public Engine(GameController gameController, IReader reader, IWriter writer)
    {
        this.gameController = gameController;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        StringBuilder sb = new StringBuilder();
        string result = "";

        while (true)
        {
            string[] input = reader.ReadLine().Split();
            string commandType = input[0];

            if (commandType == OutputMessages.EndCommand)
            {
                break;
            }

            string[] args = input.Skip(1).ToArray();

            switch (commandType)
            {
                case "Soldier":
                    if (input[1] == "Regenerate")
                    {
                        gameController.RegenarateSoldier(args);
                    }
                    else
                    {
                        result = gameController.AddSoldierToArmy(args);
                    }
                    break;
                case "WareHouse":
                    gameController.AddWeaponsToWareHouse(args);
                    break;
                case "Mission":
                    result = gameController.CompleteMission(args);
                    break;
            }

            if (!string.IsNullOrEmpty(result))
            {
                sb.AppendLine(result);
                result = "";
            }
        }

        sb.AppendLine(gameController.GetStatistics());

        writer.WriteLine(sb.ToString().TrimEnd());
    }
}
