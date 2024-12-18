using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.Intrinsics.Arm;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;


namespace Lab6Dychenko
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _Catalog = By.CssSelector("body > div.wrap > header > div.bottom > div > div.catalog.modal_cont"); //каталог товаров путь
        private readonly By _VkLink = By.CssSelector("body > div.wrap > header > div.info > div > div.soc_links > a:nth-child(1)"); //ссылка на вк
        private readonly By _InputBox = By.CssSelector("body > div.wrap > header > div.bottom > div > div.search > form > input"); // поле для ввоода и поиска товаров
        private readonly By _ButtonToClick = By.CssSelector("body > div.mango-call-site > button");
        private const string inputText = "Iphone";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://boltyn.ru/?utm_source=yandex&utm_medium=cpc&utm_content=14307158177&utm_campaign=1_M_Master&utm_term=ST:search|S:none|AP:no|PT:premium|P:2|DT:desktop|RI:2|RN:%D0%A1%D0%B0%D0%BD%D0%BA%D1%82-%D0%9F%D0%B5%D1%82%D0%B5%D1%80%D0%B1%D1%83%D1%80%D0%B3|CI:72181360|GI:4853005150|PI:37116533472|AI:14307158177|KW:---autotargeting&yclid=13184601082620805119");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void MainTitle() //проверка заголовка страницы
        {
            Assert.That(driver.Title, Is.EqualTo("Интернет-магазин БОЛТУН – самые низкие цены на телефоны и смартфоны Samsung, iPhone, Xiaomi, Redmi, Huawei | Купить аксессуары планшеты, ноутбуки - boltyn.ru"), "Несовпало");
           
        }
        [Test]
        public void CatalogVisible() //проверка видимости каталога
        {
            IWebElement Catalog = driver.FindElement(_Catalog);
            Catalog.Displayed.Equals(true);
            Thread.Sleep(1000);
        }

          [Test] 
           public void LinkToVk() //переход в группу вк
           {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement vkLink = driver.FindElement(_VkLink);
            vkLink.Click();
            Thread.Sleep(1000);
            // Ожидание заголовка
            wait.Until(d => d.Title == "Boltyn | VK");
            // Проверка наличия элемента VK ссылки
            Assert.That(vkLink.Displayed, Is.True, "Ссылка на VK не видна");
           }

        [Test]
        public void InputWord() //проверка на ввод слова Iphone  в поиске товаров
        {
            IWebElement InputBox = driver.FindElement(_InputBox);
            Thread.Sleep(1000);
            InputBox.Click();
            Thread.Sleep(1000);
            InputBox.SendKeys(inputText);
            Assert.That(InputBox.GetAttribute("value"), Is.EqualTo(inputText));
        }


        [Test]
        public void ButtonCLick()
        {
            IWebElement ButtonToClick = driver.FindElement(_ButtonToClick);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(1000);
            ButtonToClick.Click();
        }

        [TearDown]
        public void TearDown() {
            driver.Close();
        }

    }
}