using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_test
{

    [TestFixture]
    public class avito_test
    {
        private bool IsLoad30Sec(string xPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath(xPath));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        private bool IsLoad15sec(string xPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 15));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath(xPath));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        private bool IsLoadEnabled5sec(string xPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeEnabled =
                    webDriver.FindElement(By.XPath(xPath));
                    return elementToBeEnabled.Enabled;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        private bool IsLoadDisplayed10sec(string xPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath(xPath));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        private bool IsLoadEnabled10sec(string xPath)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeEnabled =
                    webDriver.FindElement(By.XPath(xPath));
                    return elementToBeEnabled.Enabled;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        //https://www.avito.ru/
        IWebDriver webDriver = new ChromeDriver();
        [TestCase]
        public void mainTitle()//проверка заголовка
        {
            webDriver.Url = "https://www.avito.ru/";
            if (IsLoad30Sec("//*[@id=\"app\"]/div[2]/div/div[2]/div/div[3]/button"))
            {
                Assert.AreEqual("Авито: недвижимость, транспорт, работа, услуги, вещи", webDriver.Title);
            }
            webDriver.Close();
        }

        [TestCase]
        public void displayed_test()//проверка видимости объектов
        {
            webDriver.Url = "https://www.avito.ru/";
            if (IsLoad30Sec("//*[@id=\"app\"]/div[2]/div/div[2]/div/div[5]/div[1]/span/span/div"))
            {
                IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[2]/div/div[2]/div/div[5]/div[1]/span/span/div"));
                bool res = button.Displayed;
                Assert.IsTrue(res);
                webDriver.Close();
            }
        }
       

        [TestCase]
        public void gotolink_test()//переход по ссылке
        {
            bool res = false;
            webDriver.Url = "https://www.avito.ru/";
            if (IsLoad30Sec("//*[@id=\"app\"]/div[3]/div[1]/div/div[1]/div[2]/a"))
            {
                IWebElement link = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div[1]/div/div[1]/div[2]/a"));
                link.Click();
                res = true;
                Assert.IsTrue(res);
                webDriver.Close();
            }

        }

        [TestCase]
        public void input_test()//проверка ввода и эмуляция нажатия на кнопку
        {
            bool res = false;
            webDriver.Url = "https://www.avito.ru/";
            if (IsLoad30Sec("//*[@id=\"app\"]/div[1]/div/div/div[2]/a"))
            {
                IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div/div/div[2]/a"));
                button.Click();
            }

            if (IsLoadDisplayed10sec("/html/body/div[7]/div/div/div/div/span/div/div[1]/form/div[3]/div/div[1]/div/div/div/label/input"))
            {
                IWebElement TextBoxNumber = webDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/span/div/div[1]/form/div[3]/div/div[1]/div/div/div/label/input"));
                TextBoxNumber.SendKeys("vitok.joy@gmail.com");

                IWebElement TextBoxPassw = webDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/span/div/div[1]/form/div[3]/div/div[2]/div/div/div/label/input"));
                TextBoxPassw.SendKeys("Avito376");
            }
            IWebElement chbxRemPassw = webDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/span/div/div[1]/form/div[3]/div/div[3]/div/div/div/div/label"));
            chbxRemPassw.Click();

            IWebElement ButLogIn = webDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/span/div/div[1]/form/div[5]/div/div/div/div/div/button"));
            ButLogIn.Click();

            res = true;
            Assert.IsTrue(res);


            webDriver.Close();
        }

        [TestCase]
        public void individual_test()
        {
            bool res = false;
            webDriver.Url = "https://www.avito.ru/";

            //----------------------------------(Выбираем категорию "")-------------------------------------------
            if (IsLoad15sec("//*[@id=\"app\"]/div[2]/div/div[2]/div/div[1]/div"))
            {
                IWebElement link_category = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[2]/div/div[2]/div/div[1]/div"));
                link_category.Click();

                IWebElement link_car = webDriver.FindElement(By.XPath("//*[@id=\"category\"]/option[3]"));
                link_car.Click();
            }


            //----------------------------------(Добавляем галочку "Сначала из Екатеринбурга")-------------------------------------------
            if (IsLoad15sec("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[2]/div/div[2]/div/div/div/div"))
            {
                IWebElement chbxAtFirstEkb = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div[2]/div/div[4]/div[1]/label[3]"));
                chbxAtFirstEkb.Click();
            }


            //----------------------------------(Добавляем (ино)марку автомобиля)-------------------------------------------
            IWebElement txtbxMark = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[2]/div/div[2]/div/div/div/div"));
            txtbxMark.Click();

            IWebElement txtbxMarkAdd = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[2]/div/div[2]/div/div/div/div/label/input"));
            txtbxMarkAdd.SendKeys("Volkswagen");

            if (IsLoadDisplayed10sec("/html/body/div[9]/div/ul"))
            {
                IWebElement selectMark = webDriver.FindElement(By.XPath("/html/body/div[9]/div/ul"));
                selectMark.Click();
            }



            //----------------------------------(Добавляем модель автомобиля)-------------------------------------------
            if (IsLoadEnabled5sec("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[3]/div/div[2]/div/div/div/div/label")) 
            {
                IWebElement txtbxModel = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[3]/div/div[2]/div/div/div/div/label"));
                txtbxModel.Click();
            }

            if (IsLoadEnabled5sec("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[3]/div/div[2]/div/div/div/div/label/input"))
            {
                IWebElement txtbxModelAdd = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[3]/div/div[2]/div/div/div/div/label/input"));
                txtbxModelAdd.SendKeys("T");
            }

            if (IsLoadDisplayed10sec("/html/body/div[8]/div/ul/li[4]")) 
            {
                IWebElement selectModel = webDriver.FindElement(By.XPath("/html/body/div[8]/div/ul/li[4]"));
                selectModel.Click();
            }



            //----------------------------------(Добавляем поколение автомобиля(год производства))-------------------------------------------
            if (IsLoadEnabled5sec("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[4]/div/div[2]/div/div/div/div/div")) 
            {
                IWebElement txtbxGeneration = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[4]/div/div[2]/div/div/div/div/div"));
                txtbxGeneration.Click();

                IWebElement selectGeneration = webDriver.FindElement(By.XPath("/html/body/div[8]/div/div[2]"));
                selectGeneration.Click();
               
            }


            //----------------------------------(Добавляем коробку передач)-------------------------------------------
            if (IsLoadEnabled10sec("/html/body/div[1]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[8]/div/div[2]/div/div/div/div/label")) 
            {
                IWebElement txtbxTransmission = webDriver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[8]/div/div[2]/div/div/div/div/label"));
                ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView();", txtbxTransmission);
                txtbxTransmission.Click();

                if (IsLoadEnabled5sec("/html/body/div[1]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[8]/div/div[2]/div/div/div/div/div/label[1]"))
                {
                    IWebElement selectTransmission = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[8]/div/div[2]/div/div/div/div/div/label[1]"));
                    selectTransmission.Click();
                    txtbxTransmission.Click();
                }
            }

           
            //----------------------------------(Добавляем тип кузова)-------------------------------------------
            IWebElement TypeBody = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[9]/div/div[2]/div/div/div/div/ul/li[6]/div"));
            TypeBody.Click();
           

            //----------------------------------(Добавляем тип двигателя)-------------------------------------------
            IWebElement chbxTypeEngine = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[10]/div/div[2]/div/div/div/div/div/ul/li[1]/label"));
                    chbxTypeEngine.Click();


            //----------------------------------(Добавляем пробег)-------------------------------------------
            IWebElement txtbxMileage = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[11]/div/div[2]/div/div/div/div/div[1]"));
            txtbxMileage.Click();

            IWebElement selectMileage = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[11]/div/div[2]/div/div/div/div/div[1]/div/ul/li[3]"));
            selectMileage.Click();


            //----------------------------------(Добавляем привод)-------------------------------------------
            IWebElement chbxDriverUnit = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[13]/div/div[2]/div/div/div/div/ul/li[3]/label"));
            chbxDriverUnit.Click();


            //----------------------------------(Добавляем Регистрацию автомобиля в РФ)-------------------------------------------
            IWebElement RegistrCarRF = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[15]/div/div[2]/div/div/div/div/div/div/div[2]"));
            RegistrCarRF.Click();


            //----------------------------------(Добавляем кол-во владельцев машины)-------------------------------------------
            IWebElement chbxOwnerCount = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[18]/div/div[2]/div/div/div/div/div/div[2]"));
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView();", chbxOwnerCount);
            chbxOwnerCount.Click();

            //----------------------------------(Добавляем цвет автомобиля)-------------------------------------------
            IWebElement selectColor = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[19]/div/div/div/div/div/div/ul/li[4]"));
             selectColor.Click();


            //----------------------------------(Добавляем пункт "От собственников и Партнёров")-------------------------------------------
            IWebElement chbxFromOwnAndPartner = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[21]/div/div/div/div/div/div/ul/li/label"));
            chbxFromOwnAndPartner.Click();


            //----------------------------------(Добавляем рейтинг пользователя)-------------------------------------------
            IWebElement chbxMore4Stars = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[1]/form/div[23]/div/div[2]/div/div/div/ul/li/label"));
            chbxMore4Stars.Click();


            //----------------------------------(Нажимаем кнопку "Показать")-------------------------------------------       
            IWebElement btnShow = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[4]/div[3]/div[1]/div/div[2]/div[2]/div/button[1]"));
            btnShow.Click();

            res = true;
            Assert.IsTrue(res);
            
            webDriver.Close();
        }
    }
}
