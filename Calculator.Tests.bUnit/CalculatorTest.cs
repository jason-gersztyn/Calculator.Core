using System;
using Xunit;
using Bunit;
using Shouldly;

using Calculator.Core.Pages;

namespace Calculator.Tests.bUnit
{
    public class CalculatorTest : TestContext
    {
        [Fact]
        public void AddingTwoNumbersProducesCorrectResult()
        {
            // ASEEMBLE:
            // Renders the Counter component
            var page = RenderComponent<CalculatorComponent>();

            // ACT:
            // Use a Find to query the rendered DOM tree and find the button element
            // and trigger the @onclick event handler by calling Click
            page.Find("#two").Click();

            page.Find("#plus").Click();

            page.Find("#two").Click();

            page.Find("#equals").Click();

            // ASSERT:
            // Use a Find to query the rendered DOM tree and find the paragraph element
            // and assert that its text content is the expected (calling Trim first to remove insignificant whitespace)
            page.Find("#result").TextContent.Trim().ShouldBe("4");
        }

        [Fact]
        public void SubtractingTwoNumbersProducesCorrectResult()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#eight").Click();

            page.Find("#minus").Click();

            page.Find("#five").Click();

            page.Find("#equals").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("3");
        }

        [Fact]
        public void MultiplyingTwoNumbersProducesCorrectResult()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#two").Click();

            page.Find("#times").Click();

            page.Find("#six").Click();

            page.Find("#equals").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("12");
        }

        [Fact]
        public void DividingTwoNumbersProducesCorrectResult()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#six").Click();

            page.Find("#divide").Click();

            page.Find("#three").Click();

            page.Find("#equals").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("2");
        }

        [Fact]
        public void ClearButtonRemovesAllValues()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#six").Click();

            page.Find("#three").Click();

            page.Find("#decimal").Click();

            page.Find("#one").Click();

            page.Find("#clear").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("0");

        }

        [Fact]
        public void DivideByZeroProducesHelpfulMessage()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#two").Click();

            page.Find("#seven").Click();

            page.Find("#divide").Click();

            page.Find("#zero").Click();

            page.Find("#equals").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("Cannot Divide by Zero");
        }

        [Fact]
        public void ClickingOperatorBeforeAddingValueHasNoEffect()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#divide").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("0");
        }

        [Fact]
        public void ClickingOperatorResetsCurrentValueToZero()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#five").Click();

            page.Find("#divide").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("0");
        }

        [Fact]
        public void DecimalDoesNotAllowMultipleValues()
        {
            var page = RenderComponent<CalculatorComponent>();

            page.Find("#two").Click();

            page.Find("#decimal").Click();

            page.Find("#three").Click();

            page.Find("#decimal").Click();

            page.Find("#result").TextContent.Trim().ShouldBe("2.3");
        }
    }
}