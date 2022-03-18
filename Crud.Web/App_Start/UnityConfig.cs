using StudentServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Crud.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //--> BusinessServices.
            container.RegisterType<IStudentsService, StudentsService>();

            //--> businessentity.
            //container.RegisterType<IStudentEntity, StudentEntity>();
            //container.RegisterType<IBaseEntity, BaseEntity>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}