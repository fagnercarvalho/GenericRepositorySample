namespace GenericRepositorySample.Data
{
    public class UnitOfWork
    {
        public CustomerRepository Customers { get; private set; }

        public Repository<Order> Orders { get; private set; }

        private readonly Context context;

        public UnitOfWork(
            Context context, 
            CustomerRepository customerRepository, 
            Repository<Order> orderRepository)
        {
            this.context = context;
            this.Customers = customerRepository;
            this.Orders = orderRepository;
        }

        public int SaveChanges()
        {
            var rowsAffected = 
                this.context.SaveChanges();

            return rowsAffected;
        }
    }
}
