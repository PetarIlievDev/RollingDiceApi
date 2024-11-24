# RollingDiceApi

### Set up the testing
* For setting up the unit test you have to load runsettings file (available at `{Solution directory}\Tests\CodeCoverage.runsettings`), then run the tests. Would recommend to install [Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage2022) extention, to be sure that the coverage format of the runsettings file fits to the Visualization of unit test code coverage.

* For running the mutation testing:
  * Open `Comand prompt` and navigate to project(solution) directory.
  * Run command `dotnet tool restore`. Tool `dotnet-stryker` should be restored.
  * Run command `dotnet stryker`.
  * When it's completed, the reports could be found in `{Solution directory}\StrykerOutput`.