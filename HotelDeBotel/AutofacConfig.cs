using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using HotelDeBotel.Models;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;
using HotelDeBotel.Repository.Repositories;

namespace HotelDeBotel
{
    internal class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<HotelContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<GuestRepository>()
                .As<IGuestRepository>();
            builder.RegisterType<RoomRepository>()
                .As<IRoomRepository>();
            builder.RegisterType<BookingRepository>()
                .As<IBookingRepository>();
            builder.RegisterType<DiscountRepository>()
                .As<IDiscountRepository>();
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();

        }

    }
}