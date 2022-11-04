using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ProductManager.Pages;

public class Index_Tests : ProductManagerWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
