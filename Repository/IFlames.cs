using CSIT.Flames.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSIT.Flames.Api.Flames;

namespace CSIT.Flames.Api.Repository
{
    public interface IFlames
    {
        Task<string> check(Person person);
    }
}
