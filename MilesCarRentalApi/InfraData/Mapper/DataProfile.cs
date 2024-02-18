using AutoMapper;

namespace InfraData.Mapper
{
    public class DataProfile:Profile
    {
        public DataProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {

            });
        }
    }
}
