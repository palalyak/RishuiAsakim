using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Infrastructure.Models;
using Infrastructure.ServicesDB;
using NUnit.Framework.Internal;

namespace Infrastructure
{
    public class Ser003Tests
    {
        string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJhcGk6Ly81M2JmYTAyYy05NDUzLTRmZWItYjAxNy0zOWYwYzczNmZhMjEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9hYTY0MGYxMC05NWY4LTRmMDUtOTZmMS01MjlkYmJjMTE4OTcvIiwiaWF0IjoxNzAxMDIzODM0LCJuYmYiOjE3MDEwMjM4MzQsImV4cCI6MTcwMTAyNzk0NSwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhWQUFBQWVoWGFoVHZPREQ5TjRsUFhHaUpSaG5BTUsxbGdjeGdQZWY4MzdjdFdVWW5tUkVMeWJHOVp2WENoNExCU2FTVXhGcUtqS2g4bFZxT0FTcTk2ZFdJYUFBc1dwanlZajBheVZqSXZIZ3ZrTjFJPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiI4MDhjZDhjMi02Mzg2LTRiYjQtYjk5ZC01MWNkYzNjOWQyZTgiLCJhcHBpZGFjciI6IjAiLCJmYW1pbHlfbmFtZSI6Itek15zXplx1MDAyN9eZ16bXp9eZIiwiZ2l2ZW5fbmFtZSI6IteQ15zXm9eh16DXk9eoIiwiZ3JvdXBzIjpbIjFjZTMyNDEwLWJkZmUtNDk0Yi1iZjc0LWE3YmNjY2Q3ZjBkMSIsIjdmNTg3MTE1LWRiMzEtNDM0Yy1hZWFjLTE5MWM5NmY0NDc3OSIsIjMyMGM5MTE4LTE5NTktNDkzZi05ZWNlLWU3ZWVlNmYxMDNiMCIsIjc0MWQ3OTE5LTYyNWMtNGI2OS1hZWRjLThjZjQ4MjZhYWRjNSIsImE0YzlmNDFhLTEzODYtNDczMi1hNTYzLWZkMjNiNzYwOTQ1YiIsImFiMzY4YjFmLTg3NGQtNDQ5NS05ZDVkLTI2MjBkODVmM2NlZiIsIjUxZmNjNTIxLWYwZjgtNDYzOS1iNWI2LWEyMzAxYzVhOTIyZCIsIjA4MTRjODJkLTJkOTQtNDM4OS1iOWU3LTM3ZTczNjQ0ZjQ5NCIsIjc1YjYwZDMyLTFjYzgtNGM2Zi1iM2Q2LTEzN2U1MjY1ZTI5YSIsIjAzYzMyZTM5LWRmMmYtNGVmOC05NTJlLTEzMmVhZTE4MmRhOSIsIjI5NzY1MjNkLWJmOWItNDhlMS04MGUyLTNlNDdkODBmOTY2MCIsImRmNmM1NzQwLWM5ZGYtNGZmMC05OTY5LTQ2OTZiZjkxNzdiNiIsIjU3MDUwNDRkLTIyMGItNDgxNy1iMTdhLWE5MzBlYWMzODdkZiIsIjhhY2RlMTUwLWMxNzAtNGVjYS1iNjg5LTg1NTdkOTEzOWZlZSIsImY3YTM3YjU0LWI2MDgtNGJiZS1iMzIxLTdmZDdjNGY5NTRhNyIsIjIzODk0MTU2LWE3MjEtNGMyZC1hYjUxLTkxMDI4ZDgxZjJlZCIsImZiYTZjNTYyLTkyZjAtNDIwZC1iOTZiLTlkODBiMGM0YTRiNyIsImY1Zjk5NzZkLWZhNTMtNDFmZi1iNWEyLTMzYWQ0ZmNkYzExMyIsImQyNWEwZTc5LTdkOTYtNDNiOS05MTYxLTQ0NTM5OWI5ZDY4YiIsIjg0NTYzZTdiLWJiNTItNDlkMC1iMTNkLWYxYWViZjZlMDExYSIsIjE3YTU4ZjdkLTBjY2ItNDUxMy04MTUwLTQ4MmY0MDYxNGIxMCIsIjBjNTE2NTgxLTE5YmQtNDIwZS1hNWVkLTA3NWIyYmQ5ODJiMyIsIjU3Y2YwODg0LTVlNTQtNDUzOC1hNDg0LTZkMjZjNWRhZmQzMSIsImJjOTBhNTg0LWFmZTItNDA5NC1iMGUxLWQwNDMwYWY2MjQzMiIsImIyZjcxMDg2LTM4ZTAtNDNhYi04YjMxLWY1OWMyZDU5YmM4NyIsIjU5ZWUyNjhmLWE4MWQtNDNkYi04MzczLTdiNjIwZTU3MjU3OSIsIjNmOTA1NWE2LWZmMzQtNDYwYi05MGJiLTEzZDNjYTFjYTlkMSIsImM3MWViMGE3LWJlZmUtNDY3Ny04ZTU1LWI2MjA2MThkMTM4MyIsIjdkYTUxMmE4LTYyYWYtNGI0Ni1hNDA3LWM1NDg1NGE1YWUyNCIsIjI0ZGJkM2E4LWJlZmUtNDNiMS05NDhjLWQ4MjBhNjY2ZmJmZiIsImUwMzNmYWFjLTFjNzMtNDg4My04NDJkLWRlYThhMzEyMTEwZiIsIjk5ZWZkNmIyLTM2MTctNDllYy04MzM3LTIwYTIzMWJiMGZlMSIsImFjMTZlNWIzLTU0N2ItNDJmYS05ZjY4LTdhYWU0NmQ2ZGUzNyIsImFlNzJkY2JhLTlmMjEtNGU1Ni1hMDlhLTNiYzE2NjQ2OTQwYSIsIjkxZWRmNGJiLTdmOTItNDY3Yi04M2M4LTk1NDA2YTZmNWE2ZCIsImE3OGY2OWMyLTY1ZTEtNDIzZS05OWI5LWJlNDVmY2I5ZWU2YSIsImZmYTU0ZGMzLWNhYWEtNGNiZi1hZWUxLTA1NzNjMTJiYjcwMSIsIjlmMWE1N2Q4LTU2MDQtNDZhNC04ZWIxLWZkN2E0NjgwYTA4ZiIsIjIzNmE1OWU1LWQ2NDUtNDVkZi04ZWQwLWMzZDUyNGE5YWIzMCIsIjEzNzY1ZGU1LWQ4ZTgtNDU2Mi1iMjI4LWIwMTExMjNkMWNjMiIsImNkOGI4NWYyLWFjNjYtNGNlNi1hMTJhLWE4ZDkzN2Q4ZTlhMyIsImU4MGUwYmRkLThiZGUtNDE0Yi04NWNiLWE1ZmE5ZGQ0ZDYxMSIsIjM4ZjM5MTRmLTIyNDgtNDY4MS04Y2Q4LTJlNjIxYTRjNWQ0YSIsImIwZDg4ZDA2LTI4Y2UtNDRmNC04NGI3LTA0NDY4ODMwYjU4ZSIsIjgzYTg0ZmQwLWU5ZTUtNDJmNi1hMmJiLWY5MDAzNDE1ZjBhYSIsImNiMzViNTA2LTc3NDMtNGY2Ny1hYTc2LWY3ODQ3OTY3MDgzNyJdLCJpcGFkZHIiOiIxOTkuMjAzLjE0MC4yNSIsIm5hbWUiOiLXkNec15vXodeg15PXqCDXpNec16ZcdTAwMjfXmdem16fXmSAtINee16rXm9eg16oiLCJvaWQiOiI4NzQ5NzNmYy01YTBiLTQxZjMtYWZkZS1kYzNlMzY2YmZkZTAiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtOTYxMzAxMzExLTQ5NTYxNDM2NS0xMjI1MjE5MzgxLTExMzkyMiIsInJoIjoiMC5BU1VBRUE5a3F2aVZCVS1XOFZLZHU4RVlseXlndjFOVGxPdFBzQmM1OE1jMi1pRWxBQzQuIiwic2NwIjoiYWNjZXNzX2FzX3VzZXIiLCJzdWIiOiI5bm1wMHMyUW5QQ3V0dTgwcjFzN1ltd2U2RDNiOXpnTzZ3NGtzVTBJOUNNIiwidGlkIjoiYWE2NDBmMTAtOTVmOC00ZjA1LTk2ZjEtNTI5ZGJiYzExODk3IiwidW5pcXVlX25hbWUiOiJjMjE2ODkxMEB0ZWwtYXZpdi5nb3YuaWwiLCJ1cG4iOiJjMjE2ODkxMEB0ZWwtYXZpdi5nb3YuaWwiLCJ1dGkiOiJnOVNrYmtmS05VdURyd1dpbUVneUJBIiwidmVyIjoiMS4wIiwid2lkcyI6WyJiNzlmYmY0ZC0zZWY5LTQ2ODktODE0My03NmIxOTRlODU1MDkiXX0.g2Xfs9PrI3blQHcQZT7824Lm9phWq7gMwURIi7_wxQFNbLL0fh_NSoZ9FX1G6mN4A67t5q8sl93Z3fvnrS4F3XQEVE9mWpfc5sDlo2Bt6R40rIc0Cw-Q8Pa-i80v0fbwoOnRJzg0jd8ILznfYR7pTVkTqAOdKtmPLlKF1zurCicC8o5b-ohV8VF_lUtRzayjzHG8GRrnlyZHSN_t3uqcFeLEaAS7zizMi3i-YvrSE_-_C6cQdyl_cqyzROZ67-UdBV9mnDZ00mWoyjEq0lXvd1jQJ_uc0YGSSB-_cEXvpSfp2YrN_k9-QUcPf5PF-95nh3wlGBYo2kwlXU7Bunqv4w";
        DataQueryService query  = new DataQueryService();

        int bakashaIdToUpdate = 110;
        int daysBack = 2;

        
        public void SetUp()
        {
            /* 
            How add a new API: 
            1. add newabstract method into IAPIClient inteface
            2. add URL into Endpoints class  
            3. implement interface into APIClient class
            4. add response class model into ModelAPI.Response folder
            5. add request class model into ModelAPI.Request folder

            How does the authentication mechanism work:
            1. The APIAuthenticator class has been created in Auth folder, which is responsible 
            for creating tokens. It inherits from the RestSharp abstract class AuthenticatorBase and
            implemented method GetAuthenticationParameter
            */

        }

        public void Ser003()
        {
            DateTime testDay = WorkDays.CalcWorksDays(accessToken, daysBack);

            //query.updatetahanotcreationday(bakashaidtoupdate, testday); // change submition start day in db
            //var codeparit = query.getcodeparit(bakashaidtoupdate); // get codeparit by bakashaid from db
            //var codestation = query.gettahanot(codeparit); // get stations code by codeparit from db
            //query.updatetahanot(codestation, testday); // change station start day in db

        }

    }
}

