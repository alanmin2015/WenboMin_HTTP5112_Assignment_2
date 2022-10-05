using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace WenboMin_HTTP5112_Assignment_2.Controllers
{
    public class AssignmentController : ApiController
    {
        /// <summary>
        /// CCC 2006 J1 Problem, calculate the total calories
        /// </summary>
        /// <param name="burger"></param>
        /// <param name="drink"></param>
        /// <param name="side"></param>
        /// <param name="dessert"></param>
        /// <example>4/4/4/4</example>
        /// <returns>0</returns>
        /// <example>1/2/3/4</example>
        /// <returns>691</returns>

        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            int burgerCalorie=0;
            int drinkCalorie=0;
            int sideCalorie=0;
            int dessertCalorie=0;

            switch (burger)
            {
                case 1:
                    burgerCalorie = 461;
                    break;
                case 2:
                    burgerCalorie = 431;
                    break;
                case 3:
                    burgerCalorie = 420;
                    break;
                case 4:
                    burgerCalorie = 0;
                    break;
            }
            switch (drink) 
            {
                case 1:
                    drinkCalorie = 130;
                    break;
                case 2:
                    drinkCalorie = 160;
                    break;
                case 3:
                    drinkCalorie = 118;
                    break;
                case 4:
                    drinkCalorie = 0;
                    break;
            }
            switch (side)
            {
                case 1:
                    sideCalorie = 100;
                    break;
                case 2:
                    sideCalorie = 57;
                    break;
                case 3:
                    sideCalorie = 70;
                    break;
                case 4:
                    sideCalorie = 0;
                    break;
            }
            switch (dessert)
            {
                case 1:
                    dessertCalorie = 167;
                    break;
                case 2:
                    dessertCalorie = 266;
                    break;
                case 3:
                    dessertCalorie = 75;
                    break;
                case 4:
                    dessertCalorie = 0;
                    break;
            }
           int totalCalorie = burgerCalorie + drinkCalorie + sideCalorie + dessertCalorie;
            string message = "Your total calorie count is " + totalCalorie;
            return message;
        }

        /// <summary>
        /// CCC 2006 J2 Problem, determines how many ways the dice can roll the total value of 10
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <example>6/8</example>
        /// <returns>There are 5 total ways to ge the sum 10.</returns>
        /// <example>12/4</example>
        /// <returns>There are 4 eays to get the sum 10.</returns>
        /// <example>3/3</example>
        /// <returens>There are 0 ways to get the sum 10.</returens>
        /// <example>5/5</example>
        /// <returns>There is 1 way to get the sum 10.</returns>
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            int answer = 0;
            string message;
            for (int i = 0; i <= m; i++)
            {
                if (10 - i <= n && 10 - i > 0)
                { answer = answer + 1; }
            }
            switch (answer)
            {
                case 1:
                    message = "There is " + answer + " way to get the sum 10";
                    break;
                default:
                    message = "There are " + answer + " ways to get the sum 10";
                    break;
            }
            return message;
        }
        /// <summary>
        /// CCC 2006 J3 Problem, calculate the total typing time for a word on an old nine key smart phone
        /// https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2006/index.html
        /// </summary>
        /// <param name="W"></param>
        /// <example>a, dada, bob, abba, cell, www</example>
        /// <returns>1, 4, 7, 12, 13, 7</returns>

        [HttpGet]
        [Route("api/J3/InputTime/{w}")]
        public int InputTime(string W)
        {
            int time = new int();
            string word = W.ToUpper();
            if (word == "HALT")
            { }
            else
            {
                

                int length = W.Length;
                byte[] character = Encoding.ASCII.GetBytes(word);


                List<int> termList = new List<int>();
                List<int> termList2 = new List<int>();
                for (int i = 0; i < length; i++)
                {

                    if (character[i] >= 65 && character[i] <= 67)
                    { termList.Add(2); }
                    else if (character[i] >= 68 && character[i] <= 70)
                    { termList.Add(3); }
                    else if (character[i] >= 71 && character[i] <= 73)
                    { termList.Add(4); }
                    else if (character[i] >= 74 && character[i] <= 76)
                    { termList.Add(5); }
                    else if (character[i] >= 77 && character[i] <= 79)
                    { termList.Add(6); }
                    else if (character[i] >= 80 && character[i] <= 83)
                    { termList.Add(7); }
                    else if (character[i] >= 84 && character[i] <= 86)
                    { termList.Add(8); }
                    else if (character[i] >= 87 && character[i] <= 90)
                    { termList.Add(9); }
                    switch (character[i])
                    {
                        case 65:
                        case 68:
                        case 71:
                        case 74:
                        case 77:
                        case 80:
                        case 84:
                        case 87:
                            termList2.Add(1);
                            break;
                        case 70:
                        case 73:
                        case 76:
                        case 79:
                        case 83:
                        case 86:
                        case 90:
                        case 67:
                            termList2.Add(3);
                            break;
                        default:
                            termList2.Add(2);
                            break;


                    }



                }

                if (termList2[0] == 1)
                { time = 1; }
                else if (termList2[0] == 2)
                { time = 2; }
                else if (termList2[0] == 3)
                { time = 3; }

                for (int j = 0; j < length - 1; j++)
                {


                    if (termList[j] != termList[j + 1])
                    { time = time + termList2[j]; }
                    else if (termList[j] == termList[j + 1])
                    { time = time + termList2[j] + 2; }
                }
            }
            return time;
        }
    }
}
