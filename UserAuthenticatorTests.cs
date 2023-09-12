using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppNUnitAssignment
{
    [TestFixture]
    public class UserAuthenticatorTests
    {
        private UserAuthenticator userAuthenticator;

        [SetUp]
        public void Setup()
        {
            userAuthenticator = new UserAuthenticator();
        }

        [Test]
        public void TestUserRegistration()
        {
            userAuthenticator.RegisterUser("Maximus", "Perseus");
            // Assert that the user is registered
            Assert.IsTrue(userAuthenticator.Login("Maximus", "Perseus"));
        }

        [Test]
        public void TestUserLogin()
        {
            // Register a user first
            userAuthenticator.RegisterUser("Maximus", "Perseus");

            // Test user login
            Assert.IsTrue(userAuthenticator.Login("Maximus", "Perseus"));
            Assert.IsFalse(userAuthenticator.Login("Maxu", "Persu"));
            Assert.IsFalse(userAuthenticator.Login("Persu", "Maxu"));
        }

        [Test]
        public void TestPasswordReset()
        {
            // Register a user first
            userAuthenticator.RegisterUser("Maximus", "Perseus");

            // Reset the password for user "Maximus" to "Maximus"
            userAuthenticator.ResetPassword("Maximus", "Maximus");

            // Attempt login with the new password
            Assert.IsTrue(userAuthenticator.Login("Maximus", "Maximus"));
        }
    }
}