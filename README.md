## Requisitos

Para conseguir rodar o sistema verifique se sua máquina possui o seguinte:

* Visual Studio 2019
* Docker
* NET 5.0 SDK

> O Visual Studio costuma notificar a ausência ou defasagem dos requisitos na hora abrir a solução. 

## Como rodar a solução

Entre no Visual Studio
1) Selecione a solução clique em "Restore Nuget Packages" 
2) Caso o botão de debug tenha escrito "Docker Compose" basta clicar que a API e o banco vão subir.

> Se o debug estiver apontando para outro projeto selecione o arquivo "docker-compose" na solution explorer e clique em "set as startup project"

Pronto! Pode usar a API.
