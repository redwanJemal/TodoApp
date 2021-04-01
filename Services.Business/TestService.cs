using Services.Data;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business
{
    public class TestService : BaseService<TestEntity>
    {
        private readonly WDSContext _wdsContext;

        public TestService(WDSContext wdsContext): base(wdsContext)
        {
            _wdsContext = wdsContext;
        }
    }
}
