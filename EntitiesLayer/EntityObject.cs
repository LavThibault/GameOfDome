namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        private static int NumberOfObject { get; set; }
        public int Id { get; private set; }


        protected EntityObject()
        {
          
        }

        protected EntityObject(int id)
        {
            Id = id;
            

        }


    }
}
