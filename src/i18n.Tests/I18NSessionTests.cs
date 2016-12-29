using System;
using System.Web;
using FakeItEasy;
using NUnit.Framework;

namespace i18n.Tests
{
    [TestFixture]
    public class I18NSessionTests
    {
        [Test]
        public void Can_handle_markup_in_text()
        {
            var context = A.Fake<HttpContextBase>();
            var session = new I18NSession();
            var text = session.GetText(context, "Take the <br />next step!");
            Console.WriteLine(text);
        }

        [Test]
        public void LoadFromDisk() {
            var context = A.Fake<HttpContextBase>();
            A.Fake<HttpSessionStateBase>( x => x.Wrapping( context.Session ).Implements(typeof(HttpSessionStateWrapper)) );

            LocalizingService.LoadFromDiskAndCache( "bg-BG", @"C:\GitHub\Property\Property.Web\locale\bg-BG\messages.po" );

            var session = new I18NSession();

            session.Set( context, "bg-BG" );

            var text = session.GetText( context, "Login in bilid", "bg-BG" );

            Assert.True( true );

            Assert.AreEqual( "Вход в bilid", text );
        }
    }
}
