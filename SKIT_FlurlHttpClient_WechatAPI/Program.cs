// See https://aka.ms/new-console-template for more information
using SKIT.FlurlHttpClient.Wechat.Api.Models;

Console.WriteLine("Hello, World!");
var options = new WechatApiClientOptions()
{
    AppId = "",
    AppSecret = "",
};
var client = new WechatApiClient(options);


/* 以公众号获取用户信息接口为例 */
var request = new CgibinUserInfoRequest()
{
    AccessToken = "51_CsptAnIBDppGu7eUCXHFz00_5Y7_1ALwMod89w7H2OmeyXLnrrpUfQU_rvpfzm6qRzxY4-Uiu4NCZ5eCF-qZ4sm4bYiUSFNDT1TfAZHoU_4jbZ70K0mmZ1dET4ViXgkAmySY_yGys53ka3kPIRSgAHALUV",
    OpenId = "checko6a39wScd10Z9cmp3qQnm9vS7Ve8"
};
var response = await client.ExecuteCgibinUserInfoAsync(request);
if (response.IsSuccessful())
{
    Console.WriteLine("昵称：" + response.Nickname);
    Console.WriteLine("头像：" + response.HeadImageUrl);
}
else
{
    Console.WriteLine("错误代码：" + response.ErrorCode);
    Console.WriteLine("错误描述：" + response.ErrorMessage);
}