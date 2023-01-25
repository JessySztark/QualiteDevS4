using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;
using Microsoft.AspNetCore.Http;

namespace WSConvertisseur.Controllers.Tests {
    [TestClass()]
    public class DevisesControllerTests {
        [TestMethod()]
        public void GetAllTest() {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetAll();
            result.ToList();
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>), "Ce n'est pas une liste de devises"); // Test du type de retour
            CollectionAssert.Contains((System.Collections.ICollection?)result, new Devise(1, "Dollar", 1.08), "Ce n'est pas une liste de devises"); // Test du type de retour
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem() {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise récupérée
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsNotFoundResult() {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetById(8);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas un NotFoundResult"); // Test du type du contenu (valeur) du retour
        }

        [TestMethod]
        public void Post_ExistingIdPassed_Returns() {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.Post(new Devise(1,"Dollar",1.08));
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            // Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas un NotFoundResult"); // Test du type du contenu (valeur) du retour
            // Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult), "Pas un ActionResult"); // Test du type de retour

            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;

            Assert.IsInstanceOfType(routeResult, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
        }
    }
}