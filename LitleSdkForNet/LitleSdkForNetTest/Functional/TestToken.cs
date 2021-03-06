﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestToken
    {
        [Test]
        public void SimpleToken()
        {
            LitleOnline lOnlineObj = new LitleOnline();
            registerTokenRequestType registerTokenRequest = new registerTokenRequestType();
            registerTokenRequest.orderId = "12344";
            registerTokenRequest.accountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";
            registerTokenResponse rtokenResponse = lOnlineObj.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithPayPage()
        {
            LitleOnline lOnlineObj = new LitleOnline();
            registerTokenRequestType registerTokenRequest = new registerTokenRequestType();
            registerTokenRequest.orderId = "12344";
            registerTokenRequest.paypageRegistrationId = "1233456789101112";
            registerTokenRequest.reportGroup = "Planets";
            registerTokenResponse rtokenResponse = lOnlineObj.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithEcheck()
        {
            LitleOnline lOnlineObj = new LitleOnline();
            registerTokenRequestType registerTokenRequest = new registerTokenRequestType();
            registerTokenRequest.orderId = "12344";
            echeckForTokenType echeckObj = new echeckForTokenType();
            echeckObj.accNum = "12344565";
            echeckObj.routingNum = "123476545";
            registerTokenRequest.echeckForToken = echeckObj;
            registerTokenRequest.reportGroup = "Planets";
            registerTokenResponse rtokenResponse = lOnlineObj.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void TokenEcheckMissingRequiredField()
        {
            LitleOnline lOnlineObj = new LitleOnline();
            registerTokenRequestType registerTokenRequest = new registerTokenRequestType();
            registerTokenRequest.orderId = "12344";
            echeckForTokenType echeckObj = new echeckForTokenType();
            echeckObj.routingNum = "123476545";
            registerTokenRequest.echeckForToken = echeckObj;
            registerTokenRequest.reportGroup = "Planets";
            try
            {
                //expected exception;
                registerTokenResponse rtokenResponse = lOnlineObj.RegisterToken(registerTokenRequest);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
            
    }
}
