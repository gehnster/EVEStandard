# Adding New API End-Points to the Library
Hopefully this will help people add more end-points to the library quickly while keeping bugs to a minimum.

## Example

``` C#
public async Task<ESIModelDTO<List<Asset>>> GetCharacterAssetsV3Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
{
    checkAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

    var queryParameters = new Dictionary<string, string>
    {
        { "page", page.ToString() }
    };

    var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/assets/", auth, ifNoneMatch, queryParameters);

    checkResponse(nameof(GetCharacterAssetsV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

    return returnModelDTO<List<Asset>>(responseModel);
}
```

The above example has most everything that an api method could contain. It checks for auth for when OAuth scopes are required, it has a query parameter, calls the api and checks the response.

## Checklist
- [ ] Version number in method name and checkResponse are correct
- [ ] Using string interpolation for calling the api
- [ ] checkAuth is using the correct scope, if applicable
- [ ] You updated the returned model
- [ ] You have all the required query parameters
- [ ] You either added any new error codes to APIBase.cs or you made an issue for someone else to do it

## Questions
If you have any questions feel free to add an issue or ask us in the discord server found in the README.md!