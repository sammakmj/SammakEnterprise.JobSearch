//namespace SammakEnterprise.JobSearch.Middle.Services.Shared
//.Impl
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <typeparam name="TDomainBase"></typeparam>
//    /// <typeparam name="TRepository"></typeparam>
//    public abstract class EntityService<TDomainBase, TRepository> : ServiceBase<TDomainBase, TRepository>, IEntityService<TDomainBase>
//        where TDomainBase : class, IDomainBase, IEntity<int>
//        where TRepository : IRepository<TDomainBase, int>
//    {
//        #region Constructors

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="bus"></param>
//        /// <param name="repository"></param>
//        /// <param name="validationFactory"></param>
//        public EntityService(IBusControl bus, TRepository repository, IValidationFactory validationFactory) : base(bus, repository, validationFactory)
//        {
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="repository"></param>
//        /// <param name="validationFactory"></param>
//        public EntityService(TRepository repository, IValidationFactory validationFactory) : base(null, repository, validationFactory)
//        {
//        }

//        /// <summary>
//        /// 
//        /// </summary>        
//        /// <param name="repository"></param>        
//        public EntityService(TRepository repository) : base(repository) 
//        {
//        }
//        #endregion

//        #region Public Methods

//        /// <summary>
//        ///     Return the persistent instance of the given entity class with the given identifier,
//        ///     assuming that the instance exists.
//        /// </summary>
//        /// <param name="id">A valid identifier of an existing persistent instance of the class</param>
//        /// <returns>The persistent instance or proxy</returns>
//        /// <remarks>
//        ///     You should not call the base's load method to determine if an instance exists (use a query
//        ///     or NHibernate.ISession.Get``1(System.Object) instead). Use this only to retrieve
//        ///     an instance that you assume exists, where non-existence would be an actual error.
//        /// </remarks>
//        public new virtual TDomainBase Load(int id)
//        {
//            if (base.Exists(id))
//                return base.Load(id);
//            else
//                return null;
//        }

//        /// <summary>
//        /// Determines if an entity by its integer Id feild value exists in the repository and available via the service.
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public new bool Exists(int id)
//        {
//            return base.Exists(id);
//        }

//    #endregion
//    }
//}