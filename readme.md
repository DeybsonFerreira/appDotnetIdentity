
# Install Identity
-- projeto criado com a estrutura mvc em dotnet6,EF, Migration, e identityUI 6.x

# dotnet cli
- dotnet new mvc
- dotnet watch run
- dotnet new sln
- dotnet sln add "myProject.csproj"

# Identity
#passo 0
dotnet add package Microsoft.AspNetCore.Identity.UI --version 6.0.8

#passo 1
no visual studio ir em propert da solution / scaffold item/identity
1.1 > Adicionar contexto

#passo 2
Adicionar o IdentityUI no startup/program 
e adicionar o suporte de Roles e policy

#passo 3
Executar migration
add-migration InitIdentityMigration -o IdentityMigration
update-database > para criar

#passo 4
no layout , adicionar o login da partialview ( gerado pelo identity)

#Bonus
caso precisar adicionar outra versão do bootstrap do identity (dotnet 6)

<PropertyGroup>
  <TargetFramework>net6.0</TargetFramework>
  <IdentityUIFrameworkVersion>Bootstrap4</IdentityUIFrameworkVersion>
</PropertyGroup>