using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericRepositorySample.Data
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        public bool HasFilledAddress(int id)
        {
            var hasFilledAddress = this
                .Query()
                .Where(c => c.Id == id)
                .Where(c => !string.IsNullOrEmpty(c.Address))
                .Any();

            return hasFilledAddress;
        }
    }
}
