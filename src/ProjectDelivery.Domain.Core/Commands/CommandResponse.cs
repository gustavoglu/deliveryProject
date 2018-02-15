namespace ProjectDelivery.Domain.Core.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse(true);
        public static CommandResponse Fail = new CommandResponse(false);

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
