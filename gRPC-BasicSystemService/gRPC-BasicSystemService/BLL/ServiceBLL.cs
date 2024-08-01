using gRPC_BasicSystemService.DAL;

namespace gRPC_BasicSystemService.BLL
{
    public class ServiceBLL
    {
        ServiceDAL serviceDAL = new ServiceDAL();
        public string GetServiceNames()
        {
            return serviceDAL.GetServiceNames();
        }
    }
}
