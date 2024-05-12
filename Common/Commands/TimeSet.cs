using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw.Common.Commands
{
    public class TimeSet : ModCommand
    {
        public override CommandType Type
            => CommandType.World;

        public override string Command
            => "timeset";

        public override string Usage
            => "/timeset (dawn/noon/dusk/midnight)";

        public override string Description
            => "Set the time outside of Journey Mode";

        public override void Action(CommandCaller caller, string input, string[] args)
        {

            if (args[0].ToLower() == "dawn" || args[0].ToLower() == "morning")
            {
                Main.dayTime = true;
                Main.time = 0;
            }
            else if (args[0].ToLower() == "noon")
            {
                Main.dayTime = true;
                Main.time = 27000;
            }
            else if (args[0].ToLower() == "dusk" || args[0].ToLower() == "evening")
            {
                Main.dayTime = false;
                Main.time = 0;
            }
            else if (args[0].ToLower() == "midnight")
            {
                Main.dayTime = false;
                Main.time = 16200;
            }
            else throw new UsageException("Time set options are:\ndawn (or morning)\nnoon\ndusk (or evening)\nmidnight");

            caller.Reply("Let's do the time warp again");

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}