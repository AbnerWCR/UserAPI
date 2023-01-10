# UserAPI

<h1 align="center">API Rest de gerenciamento e autenticação de usuários</h1>

<p align="center">API criada para estudo de gerenciamento, validação e autenticação de usuários</p>

<p align="center" height="400" width="400">
 <a href="#objetivo">Objetivo</a> •
 <a href="#tecnologias">Tecnologias</a> •
 <a href="#config">Configurações</a> •
 <a href="#pacotes">Pacotes</a> •
 <a href="#metodos">Métodos da API</a> •
 <a href="#autor">Autor</a> •
</p>

<h4 align="center"> 
	  Projeto Finalizado! Mas aberto para possíveis Updates/Upgrades 
</h4>

<h3 id="objetivo">✅ Objetivo:</h3>
<p>A API foi criada para aplicação de conceitos de clean code, DDD e arquitetura em camadas. Foi realizado o desenvolvimento de apenas uma entidade, visando o foco nas boas práticas e técnologias envolvidas, podendo ser replicado em sistemas maiores posteriormente.</p>
<br/>
<h3 id="tecnologias">✅ Tecnologias e padrões:</h3>
<p>- .NET Core 3.2 </p>
<p>- C# </p>
<p>- EF Framework Core</p>
<p>- Modelagem de dados EF </p>
<p>- Autenticação com JWT </p>
<p>- FluentValidation </p>
<p>- Repository Patterns </p>
<p>- Arquitetura em Camadas </p>
<p>- DDD </p>
<br/>
<h3 id="config">✅ Configurações:</h3>
Para que a aplicação inicie é necessário seguir os passos:
<br/>
<p>Será necessário realizar uma primeira inserção de usuário no banco, para que o desenvolvedor consiga utilizar a aplicação, isso pode ser feito após a geração migration e update-database.</p>
<p>Iniciar arquivo secrets: dotnet user-secrets init</p>
<p>Configurar a string de conexão: dotnet user-secrets set "ConnectionStrings:default" "[STRING CONNECTION]"</p>
<p>Configurar dados de autenticação (JWT): </p>
<p>dotnet user-secrets set "Jwt:Key" "[JWT CRYPTOGRAPHY KEY]"</p>
<br/>
<br/>
<h3 id="pacotes">✅ Pacotes:</h3>
Foi utilizado alguns pacotes para auxílio dos métodos:
<p>- Automapper" Version="12.0.0"</p>
<p>- Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.32.0" </p>
<p>- Swashbuckle.AspNetCore" Version="6.4.0" </p>
<p>- Pomelo.EntityFrameworkCore.MySql" Version="5.0.4.0"</p>
<br/>
<h3 id="metodos">✅ Métodos da API:</h3>
<p>[Post] Login (para autenticação de geração do token)</p>
<p>[Post] Create (para criação do usuário)</p>
<p>[Put] Update (para alteração de nome e email de usuário)</p>
<p>[Put] Update password (para alterar apenas a senha do usuário)</p>
<p>[Delete] Delete (para deletar um usuário existente por id)</p>
<p>[Get] Get all (para solicitar todos os uusários)</p>
<p>[Get] Get by id (para solicitar um usuário por id)</p>
<p>[Get] Get by email (para solicitar um usuário por email)</p>
<br/>
<h3 id="autor">✅ Desenvolvedor:</h3>
 <p>Abner Wallace</p>
 <p>abnerwcridrugues@gmail.com</p>
