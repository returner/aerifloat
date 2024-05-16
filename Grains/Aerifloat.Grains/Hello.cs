using Aerifloat.Grains.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerifloat.Grains
{
    public class Hello : Grain, IHello
    {
        public async Task<string> SayHello()
        {
            await Task.CompletedTask;
            return Guid.NewGuid().ToString();
        }
    }
}
