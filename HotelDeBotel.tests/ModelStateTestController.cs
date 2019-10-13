using System.Web.Mvc;
using Moq;

namespace HotelDeBotel.tests
{ 
    /// <summary>
    /// Instance of a controller for testing things that use controller methods i.e. controller.TryValidateModel(model)
    /// </summary>
    public class ModelStateTestController : Controller
    {
        public ModelStateTestController()
        {
            ControllerContext = (new Mock<ControllerContext>()).Object;
        }

        public bool TestTryValidateModel(object model)
        {
            return TryValidateModel(model);
        }
    }
}