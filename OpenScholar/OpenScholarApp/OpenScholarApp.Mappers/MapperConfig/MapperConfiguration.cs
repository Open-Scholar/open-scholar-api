using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Mappers.MapperConfig
{
    public class MapperConfiguration
    {
            public static Mapper InitializeAutomapper()
            {
                //Provide all the Mapping Configuration
                var config = new MapperConfiguration(cfg =>
                {
                    //Configuring Employee and EmployeeDTO
                    cfg.CreateMap<Book, BookDto>();
                    //Any Other Mapping Configuration ....
                });
                //Create an Instance of Mapper and return that Instance
                var mapper = new Mapper(config);
                return mapper;
            }
    }
}
