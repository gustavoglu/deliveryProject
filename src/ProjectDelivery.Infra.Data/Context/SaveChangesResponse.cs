namespace ProjectDelivery.Infra.Data.Context
{
    public class SaveChangesResponse
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }
        public SaveChangesResponse(bool sucess = true, string errorMessage = null)
        {
            Success = sucess;
            ErrorMessage = errorMessage;
        }
    }
}
