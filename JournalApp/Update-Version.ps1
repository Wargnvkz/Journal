# Update-Version.ps1

$projectFile = "JournalApp.csproj"
$pubxmlFile = "Properties\PublishProfiles\ClickOnceProfile.pubxml"
$counterFile = "build-counter.txt"

# Увеличиваем счетчик
$build = [int](Get-Content $counterFile)
$build++
Set-Content $counterFile $build

# Формируем новую версию
$version = "1.0.0.$build"

# Обновляем .csproj
(gc $projectFile) -replace '<Version>.*?</Version>', "<Version>$version</Version>" `
                  -replace '<AssemblyVersion>.*?</AssemblyVersion>', "<AssemblyVersion>$version</AssemblyVersion>" `
                  -replace '<FileVersion>.*?</FileVersion>', "<FileVersion>$version</FileVersion>" `
                  -replace '<AssemblyInformationalVersion>.*?</AssemblyInformationalVersion>', "<AssemblyInformationalVersion>$version</AssemblyInformationalVersion>" `
| sc $projectFile

# Обновляем .pubxml
(gc $pubxmlFile) -replace '<ApplicationVersion>.*?</ApplicationVersion>', "<ApplicationVersion>$version</ApplicationVersion>" `
| sc $pubxmlFile
