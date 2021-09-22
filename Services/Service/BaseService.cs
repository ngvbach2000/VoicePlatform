using VoicePlatform.Data;

namespace VoicePlatform.Service
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
