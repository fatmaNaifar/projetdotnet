using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetdotnet.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBQUFBcUFBQYGBcXGRkXFxkYGBcXGBoaFxcZGhkXFxoaIiwjGh0pIRoYJDYnKS4vMzMzGSI4PjgyPSwyMy8BCwsLDw4PHRISHTIgIyAyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyLzI9MjIyPf/AABEIARMAtwMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAAAAQIEBQYDBwj/xABFEAACAgEDAQYCBwYCCQIHAAABAgMRAAQSITEFBhMiQVFhcQcUIzKBkaEWM0JSYrGSwRVTVHKC0dLh8EOiJDR0k7PC8f/EABkBAQEBAQEBAAAAAAAAAAAAAAABAgMEBf/EACERAQEAAgIDAQEBAQEAAAAAAAABAhESMQMhURNBImFS/9oADAMBAAIRAxEAPwDyu8UnEwzTQHzwx2GA0Y7DEOAXi42sdgGGGGAh+eLiHAYC4hOLhgNHzx2GBwG18cdiXheAuGGGAYYYZQYYYZA3FGNx6KCQCaBIBPsDwTgWMXZQEaSzSCJJLMY2NI8gBosiLXkvjcxAJ6XkqDsATKx0kwmdFLtC0bRTbB1aNSWWSvUK1/DJ30lxbO0ZIwKSOOFIh6CMRJtC/C9343lX3TneLXaV0+8J41/B3CMPxVmH44HLsDsh9bMII2UOyuy7uhKIWCk+l1V+mRNTA8btHIhR0JV1bgqR1BzVSQqvamuSLhQmvC7fQ+DITVdKbd8qzrFIva8apIVXtCNaikNKurRR+7kPQSgDg+v50Gbl7NRdKupEpO6Votnh0QyIrkl95G2mFcX8BldeXeqRl0Ko6lWTWyqysKKnwI7BHoeMoqwLLsHsp9XqE06EKXJG4iwoALFm5HAA/Ue+Q5oWjdkcUyMyMPZlJDD8CDl72FpiummmEkcTyMsETyOUFKyyzFeDZ4iX/jOS+/2mVpYtYhVk1kYdmjO5PGjpJlU/7wB/E4GUy5h7Ii+qDVvNIB431cosKOd3heJuDGVQVr4XlNmp0kKP2Q2+RY9uvBBZZGBJ0oFfZqSPfp6YFZ2z2KYEhmSUSwzhjHIFKHchp43Qk7HBPSzfNdM46Hs3fG8zv4UKMEL7d7NIRuEcaAje9cnkADknLPvPG8MWk0th4kjeaOVfuStOwZ2T4LQSjz1JAsZJ7fiA7K7NZPuk6nfX+sMgu/jtH5DArNJotHM4jSaWJ2NI06I0TE8KrNG1x2fWmAyFruzJopm08kZEquEKDklmraFr717lI97GQHIo37HPVi6P2v2U0n7w6aIyX/rDFKY91+t7f0wMHqOz9PAxSeSSSVeHWAIERh95DLITvYdDtWgbFnGazR6bwfFgllJV1R4pY1DDerEOJEbaw8hFUD8sgaxHSR0kB3q7K99d4Yhr/G85XgXOv7JjTSafUo8hadpE2ELSmJgp5HLXYr/POXaPZ0UMaq7udSQTJENuyKz5VkbrvIolR931Ppmw7DWJtBoleQRTM+rTSysAY45TIhBcHoTyA38JINdMwnaWhlgleKZCkiGmU8mz/ED/ABA9QfXAjYYl4uADDDDAYcBijEY0LwNLqe14NZFEmrLxzwp4aahE8RZIx91JksNuHQMpPxGR9DrIdI4miczzLfhEoY4o2II8Rg53SMLsCgL5N1WPPYcZmnhEmzw1jMbPQVnfZSSEcIDvrd0Bq+Lytn0XhxEurrKspidG4qk3ciru/jWBN7tdoRxTtLOzkNHMpKrvZmljZLNkerWcqAxUgoxtSCrC1Ng2GHqDfPwyw7O0sMiyFlk3RxNL5XQKxEiJtooSBTjmz06Y8dliSAzRKxPjNHtZ0oIEVwbIFtbV+HTAmdvd5DrII0kjAnSQtLKoAEo8MIruB/6gAAJrkAfLM7fP/h/T1zQL2NH9ZaGnIXTeNQddxf6sJtm7bVWdvT45SaxAjMApSv4WYMRxyCwAB+dYFj2vrYni08UW/ZDGytvVVLSyOXkkG1jwfKADyNmSdL2tE2hfRzCTcs3jaeRFVghK7XRgWB2tz09TeE3d/bqood/2Um1jLX3VB2yg+m5XDrXvt98hPoFWLUMb3wyxxDkVTeMGsV1uIevqcKrjl5F2nCOz20h8TxW1A1AYIhjFR+HsPnDfG69emK3Z0H1lNMfETxFhCybwwWSaJHG5NotN0lcEEAXnCbSRRQxvJGzO8k8cgWQKB4LRjy+Ui/OetjjCO3ZvbUf1dtHqo2khsvEyFfEgc9Sm7go38Skj3x3ZvbcccUmklR5tLIwkA4jljkArxYjbKD6FTYP52yfsiNBOdzMEhhnhb7pKTPEB4i887ZKIvqvtnCHRodN4uwswklQnxAgCpHG4YKfvEbjwOtYAjaJG31NKAbWORY4lNekjq7Fh7hQt+4yPre05ZJjqHc+KWD7l42laCbAPuhQqgD2UY7s/Rh1mkaykKK7KDRYvIsaLfoLayfZfjkrS6GKZBIqsmyaGKRN5YMsxYKyMeVYFGBHPUH3wJuv7b0usPiauGSOcgB5dMU2ykCgzxPQD/FW5rp7Vusl0oi8OBZizMrNJN4YoKGARFS6stZJPoMZ21pVjkaNU2hWkUHxBJuCuVBNfdPHTO5SD6uJfBO4ytFXivQAjVw3TrbfpgP1nbEb6KDSBHDQvK5clCreKbYbeoA4ztL3gSeBYdZG0jxjbDqEZVlVP9XJuBEie10R74RdjRtLo18oSVIGkBmRXJkcq+0M24cdKGcdDoY2imkMYZkmjjUGQxja6yki7FkeGtfjgUxr0wxBi4BhhhgMwPIr3xcUDAstb2qJGnbw68ZY1rde3wzGb6c34Y4/qOctZ2u8sSRPtJjNiQ/fKhdqo/wDNtB4PWqHNDLjSdmR6fSLrdTH4hlYppYWsI23780tUSg6BQfMavg5EXvTq1+48aKOkaQwrGB7BdnTCq7RazwhKNu7xYmi61tDOjbhxyfIPzwbWXB4G3/1DLuvmzGI9tV0oX1zZdmdnwdrRSIkUen10Sb18IBItQvraDhGvgkfzKelgYVgRwRRHBB4II6g/HCLRO2PtfEMQIMHgFd5Fr4Ih37q4baLquuVczoWNLtXgbd1mq55of2y+7sdipMJZ5yy6bTJvlK8M5P3IYz6Mx9fT8RjX70zrxpxHpo/4UhjTgf1SMC7t/UTzgRNR23I+9aUB5WmA6lSzB2jU/wAhKoSPdAffDVdqb1nHhhfrEyymmJ2MpkNLY5H2r9fhl/2D3xkMqR60RTwOdsnjRxkqDxvD7RVcHn45jU6C/YX+WFWuo7bUyLKIkWVFjVWLsQDEioj7DxuAVTyasdM4r2mhijieNX8NpHDb3DEy7N26uo8i+x6885svojlLamWJqaMaaSRUZVZQ6yRUwDA0fMfzyh0nfPVj77rIrIyspiiH30IsFUBBBIP4YTavTtZvtd8auJUSMi2QIkbIyLHtPAGxB8h8cb/pFfCMZiQr4jSr5n8pdFSuvIAVevU5AAwOBI0OsaItQDK6mORGFq6mjRqjwQGBBBBAx/8ApArtCIERZFk2gs250+7vYmyBzQFdT6m82veTsKMdmReFzNoHEeq+eoVZHPxCyMBfptb2zz4jA66mcySPIQAXZnIF1bEsav0s446tvC8GhtEhkvnduKBCPaqHSsjS/dPyP9s9Y77924tY002i/wDmdPtGqhAAZwUDLIijq1H/AIqI6jBt5uO038SGTau6ARKnWiIm3Lu55569MWHtEqkkZjRlkdZWDCQUU31RDDj7Rut+ntkHNdrddI3Y0AZ3P/xcqEliSVEW4Kx6lQWPBwMgTi4YYAMMMMBuIx4Nexwxy4G/+lSLYvZyoPsxpaSun8F/jW3PP7Oeh6DUR9q6CPQvIses0vOmLnasqVXh7j/FVD/hU+9YzVdi6qJykmmlVwarY5/IqCG/A4IvPovmZe1NPt/iMitX8pjcm/xAyo70BfruqC1t8eWq6fvDl92BfZYfVzjbqDGyaWA/vN0gozSr1jQDpuomzxmPdyxLE2SSST1JJsk/EmzgbvQxA93dSUHm+tIZK67VMNX8BmDzWdxe8UWmMum1S7tJql2Seuw0QHrrVGjXPAI6YztnuRqY7k0w+t6c8xyw/aHb6B0WyG96Ff2wMqcSs0PY/dTVzSDxIJYolIaWSRGjVI15c24FmgaAvkjM+DfNVfNe3wwN59Do/wDjpfb6pL/+SHKCCXs0qw8HUI/huY2eZHTxBGTGGCxqSN1Dg9azSfQ3Ax1krbTt+rSJuIO3c0kVLu6XwePhmd0vcvtAusZ0sq8hWZlpF9CxbptHJu/TAoRl93J0Ky6yMyECKENqJSxAURw+bkngAtsH45RyqAxC+YbiFNcnmga+PHHxzWafs+XS9lTyvG6vq5Eh5U2kCW7MwPKh2G2z6KMC87kpu1Opi1Go0rpr0kV1jnSRvEYsylVHX7zfpnnmv0jwySQycPE7I3zU1fyPX8c56Wd45EkQ08bLIh/qQhhfwsZvfpI7L8YxdpQITHqYkeQKLKOEFFgOQCtC66r8cDzyU+U/I/2zb96e1JtH2xLPC21wYjz911aCPcjj1U/5A9QMxiQM52IpZmsAKCST8AM2H0oaV11zybTsaOKnHKEiMKRuHFgqeMCw7xdjxdoQN2loFpxzq9OPvI1W0iAdfUmvvDkc2DRag32PD/8AXS/rAuVvd/t2bRTLPC1EcOp+5Ivqjj2+PUHkZrO+Wt0c2hik0g2eJqmklisXHKYaYV6Kauxwb49sDAHFwOGAYYYYHPnHAYDOkFbl3VW4Xd1Vi7rmvlzgMrLBO29Uq7V1U4XpQmkr5DzcZIcaQtI18X5QN4pTHx4dCiwk4O8AEAEAc40DR1He7d5PFA3kcRHcVP8AKZNoIHIo1YIwqpeySSSSepJsn4knriKuWMq6fbLtPm+z8KhIBdDxQA1+Wy1Fjfl6ebjlAsRik3sRL5fC4YrwfMGoV5gePbb8cCLnTT6iSM3HI8Z90dkP/tIy1d9HvGweXbJYfxtofaPD5HmKbgT6EWQboHIO+IT7lH2Qe1DhiCoNgMByQenvR9cIZPrpZOJJZHHs8juPyYnI+Wwk0viAldyeLKWBDoTGUHhr5KC+e+gscGvTDfpPtKDdBsLKbrwSDQU0r+LRJPlq69iVVByOASB1oEgfPHeK/wDO3+I/88udNNohJEXS0EIEgAezNtW29OCd3T8+RtgTmLwo1XmUM+8gMAVvy8t/5XWj1IgnF3n3Px5OWeml0wCeIl/ZuJNoYNvMtqynoWEfvwao++R4ZI11Aeh4Qluiu4eHv6FDf8HFYEMYoy0k1EDLISvnYybaSuoHhMhUgJtItgRyD6+nbUarSeKrJGPD8IqVZD+9AJV+vq20fIG764VS40LkrQyovib/AOKKRF8obzsvlPw59fTJckumawBsuFFvw7qVXBZhbcWoIu+rH0wiqGOy0jn0q+ETGW2xyLIDYEjMlq4N2hDMy36BFPuMc2r02yUCPlncx3GoYKYwqeYHyEP5iBdgEeuFVIGFYYYQDDAYYDMcMTHYCXiXjsMBuLeLhgJeAxcMAwwwwAYYYYARgMMMAwOGGAlYAYuGAYYuJgGGF4YBhhhgMs4C8XHIt8YU3nE3ZdaXsXegcvtsXyOKP43+mSH7uUaEgNiwaK8+o5zH6Ys3LGd1nh88Ky+/Z9qJDqaIB5F850PdzzUJPxKkfpfxx+mKc59Z0rjs0f7M8keIPhx1yM/Yirf2gNUeATx711rHOF8mM/qlwJyX2npRFuohgCBfNG/b19/yyIEcxmUJaK2wmm4NCr9PX3vNcmpZf6Szic5zM3svPxFCiODd+vOdGkF0jA8XyCtn1Ucn/vjZ6KMXDWXGaJjb4owcfDkcfh6ZHGqPsP1xs9fUjDI/1o/yj9c6wmRyQsZYgFiACSFHUmvT442evp9YhxkE4ZlDUoLAFqJCgnlvw64jTgEgAEWQDRF88Hr642vr66A4ucfrHptF362P/DjRqSTW0Y2evqRhjVa8dlQYYDDAbnSPqPnnMY+LqPni9NY9xp9BrFEaFkdmCbAaJFA+nPTk9cbrO0GkuMIVoBjQtjd0GHt8czX+lZkG1WoCwPKt1fvWcz2lMWL76YjaSABY9BxnHg4ccufL500uhdkcMm4bSOnBPHP61WWWp7aijZCzSRm2JI8xtVtdoHIs8G+l5z03Z2hEUT6jWalJHhWZ1DNtpjVrtjPFiuuX/aHdjsuFYjP40hlYJF5pGYs3IB2gEXY9Mkwm2vJvPLeV2xEHeNC/2okEZNuIwqt6k0SepOcl7xIjsY43CEMotxexuKahR4q82EfYvZ0SQ/XNFJFPOzIka+My7g1KNxbnhkv8csdF2RpdJpHm7Q0UYZDz4cRYBSwVRchJJJPrmuOLHDH4827d7YhmULFC0Yobi0m8lgeoFcD/AJ/DI/YPY0mrkEaEADzO7fcRfV2/yHrnqh8JnTULBF9TfTu6RGCMSM6KzG3CkDgD+L16cZd9g6WDWaJXfTRxLqFO+NPLahmC2yhSeBf4nNddLLJHnHf7ukNOEl0yEwiNVlosxVwfvtuJIDWPgK+OZQCDeoJcx7SXKqFe+aBDErxwLHW/fPYe/XZ0UGh1kkY2vL4W83d7SqgeY8DaCOPw5zyruzoIZjK0+7ZFEZDs4bg8n44al2qtRIhVQke0qKZtxO8394g/d9qHGTWEcyRJHFsZEIlfcW3ktYYj+GhY/wD5mm0vd3TahoHgil8CQSCR2amQrwp6kC2vr1yTpOxNIybtImqmUy+C23aKNAl2Phk7AD7euS316dcMceUuXSg7A7tvqpVSwI0IDuBXBJO0H+JyL+WVvb2j+ramWFdwCnaLPJQgEXXUEUc9p0PdyOOOIKaETMYzZJ3srIztXUncT8PwzzP6Q9Osc4RbPhxRpuayz9TuYn7x565JfqXWWV49RldPA0jhFG5iegIF/K+LxZl2taggD1NHkdTfTOKA+l38OudoZK44FsDZF1V/kOeRm2DpYTtDk2WPuL555Hof+YwZeAQlAAKTZPmBsn4GvTPSe6vc3SyKJnlScFqqM0gJolG53XyODt4PTMx308RdbqF4o1VAD7KlK1+g9zWZlJfahjzpnNM6Z0aGGGGAYsQ5HzxoOOiPI+eKs7hU7OkcWqX8yBxzzz6Z0/0NP18Pj33LXy5PXLfS9g6+WFSqnw+SlvGtj0IF2fXrj4+6Gtaxag8HzSD/APUHnM+mLvammimbaGJNII0Fk+UH7grir5rJTLqX2mSQkxkFDJL9wjptO6weB09suIO52sDU7xr0olrX/wBt/rl7pO4kt140RJ55RrFEchb55+WXUYuWu2MeTUTMpnnd9pLJvkkbaxr7rc7TwOR7DDtKTVyeQySSLxaeJI6mjdkO3m6DPVtH3XjjULJKWavRY0Hzogn9cjSdkaKOTxPrBU1t3CRF/LaBX/fJxp+k6eQMkoKq6sAw8qtYBX+gfh6eudIZZTaIx2gBdvJBD+hHN/LPYNJp9BGqRidSEO5bl3EEgqWskkEhmHB9cmxfUR9msiCkKgA3QbqebBazdkXk1S+TF4osGoYgbWa1oeW7UfFh0A9+md4NFrY1fwoJQkibXpCwdOhuh059M9smGij3xu6U4Xcu4kHaPLX8tdeK55yvf6r4itHKwMY5CylgwDb/AD2TdMSet89elNZLPJi8hXtLWaeMR/aRKPMAU2imJ58y9Cb/ACxvZXejVaVPDgkCJZYjYhsmgSSRfoPyz2dUZmYiRvOKY/ZmwBSg2p4HUexPxzO6nuZGRfiBms7jIoNhttgV68E9D1OOl5y+qxqfSJrwAC6ED+ir9+hHXKPtbtZ9TI0rgW5BIF+ihRRPyzcx9z4o2kM0JkQkFDCXsAHzKyA8ce19PwzNdtd30jlCRF6dm2bwAKHIJaya6jkXx8cm41LrquPdSXTK7/WDW5diHb93ceWDfwtxQPpzml7S7Dg8PxGuSMC/FWvGQfzPVLMoHrW6h65gdVpHiba6lT8RwfSwfUZbd3O2pYW8NKZXNBXbaoY/xX6fL1zXpiy9vUe76afR6dCrKY0G9nPAY9S7EdTz+AAGeWd4u0F1GrmlU+Vm8vXlVCqPzoHNZBqp9L9g820zN+8SMOsXI3USKKG9vSx16cZme9HZCwy74mR4ncgFGDBHFF4zXQi/yxpMe1ZHj8ZHj826jDDDIDFi6j54mOj6j54qzuPSOyO2UGnijdkTao5aQFWBHQCPc18+3tkQd8442KiMOd33yWVCvHQMtrz7/kM83j1LIeOt9f8ALGzahnNsef8Aw5z1/wAa/wAT7f8An8ekjvlIrcQxGiCAS7VV0LuvxAyi7e7zaqRopt2x4yQrJxw33gfgaFjpxmRWdx0Zh8icJJmPBJPrybySZfWssvFZdY6r0CHVxaqPxUciU7RIrWx3khfKRbEciuOnyyqaepKMaBrogsCnHrx1Hr+OZrQakxtYYgHg17ZsNNqo5HV/ASUoiAacDbFIEjKsxrkNVNxdkE/LtPJZ6ea+CZTcdYez12bhsJZgTwpqgeA4PT4Zz7XiWMbj91QFagAL6e1XQF+9++N+vbow8oWNFCpGVQJYX5DzsOPcn1yu7R7djnUptMaDpwpVz/UK8nzF1nSZyRw/O2uq6la2AblB8Sjs8Q+6h+rHkmrr8s6Q61tzGMSKhFFASfL6g0AGA+XtlBJG0aqVbh+Ql7v8JHX9Djo+0Gqm3NQ4BNheeeD09szjn69umXjlu5Gp0uvkUkKXQjj+IWL5qjV/Cjl1re0JImETSu8kgTwjGUC7jdrIXr1KjjMBqe1HKInhquwE2R5nDsCGv4CgK9MQ6oOUV2ZgCNxFl1XiyhPF1lueNntiePKVt+0u35IZBG7A7QRKkoqRHHWnBplNgg1dZq9JotLqo1dQrcWSOtkc30PXPI50jSVjHKZK8yO42s/ltbQ2QTfr881H0Vatl1EkLN5ZI96g+rKRe38CfyzllJpuSu/fHsJokeWed5E3XGgQDa7A+x4FL6+/vnm8g2t5T0og8/MVee3d+dH4saIL3AmRbNLUaMxO4ghCDXJ4IJHrniOpkLOzMbJYknpZJsmvneYxdZ03PZeuTUNH4kzSyOKECIwUUp++QPN+f4ZTd5NXIkzQUqRo25VCbb8RR5292Kt1zf8A0OqjaOdeA/isCwoOFaJapuo5DH55k/pK7CGk1EAV5JA8XLyPvdmWRrtqHoy5d+9Myf6ZePH4yPH3nR0LeGIMMgTHR9R88ljsjU/7NP8A/Zk/6ccvY+qFE6WcAephlA/E7cm59WdxCh0YZb2fj1Bzk/Z552n8D/zxdPK6HynqCaPTp1qxzxk8a9OjqRfUgbvQcXx8fT/vyvKe49GN8OUky9VSPGy9RjQ3wGaNYN6llKsAF4sXbelep+GRk7ODMF2WzE7QARdGj+vGXn9jOXgm/wDOUUtjLDTashwykL0oLxRqrr4+uTxoVAU7FAbdtYnynb1onrXt8RkhIEGzcVCnl2jXcyiyNpVtoJ6Hg15hl5W9QnjmF3cosNb2cNSkUkk4iVkqMFWkXxFNPuI5Uny+nHGUfanY80LASIDHwFeMhkPWjuXoTz15ydqdSvhooBrcxJtVBrgbk5rqefXcfbGL2i6BVDqVBvY/2i1YbYwIopfx983Jde+3lzuMy/zdxRlWAoAgcmj0voTz652j2sBvU7gQNwsEKOvThuL60fnlk31eZfKogkFXu4hZia4HJj631I4OQtZoZYuHjC2L3CmUqehBFijRrJomRNXJvZWqowCkZPSk9L68WePjnQq2w8Rj1A8xD3QI61fQ/gcgByODdVQ+RN0Aegv2ybo9WwV0jAqSgY2tuh8vhnru5I/E9cuMxnbWWVy3Ubwix5IXkUDdfMfDNf3FgeSeIGgsIZhstWYXYVyOvN9fjmc1pSbwxGmxkRUcN5bdbDN8L46+2aT6Ny8eqC2KkO1vML8gav7/AD4+edda3r25W+vbTfSDrJl07eGQo5SQFQW8NlIY2egsryOhrPLexoY2YmUkKpUsQpY7eQaUdTe3r8c9P+k3d4a7T95JBxzYFEjpxxf6URmN+jvspdVNLGzFfsyQdu7raGx0/iv8M88b/g7u9tjT7li1MsSuNzIFj2l1BA5I+XT43i96tfJNs+sTpIyqTGFU3ZKA2y+Xnni+NnxzYdidgaTWeJ4YdVjlAffAih/6R5jYG276+b1vKztLu8Wi1UnhSxGI7I1crUqqTTjyg1XxNWMvrsx7YGPHnLPs7uzrJgTFp3cDqQUH92GTP2M7R/2R/wDFH/15r9MJ/Y6cbvpQDDL39j9f/sr/AOKP/rwzP6Yf+ovDL499WP44zW/un/3G/tndRnLWD7Nx/Sf7Z8mPRL7fO0em2+eRTttbFgEgklasXjy8e4hVI6rTkEEHij+eTZex5ggeWJwg6FnVRRs0m4/jxiDsxhQKqqt086MeOvr+mfaws08Hkl5KjUaALI0bAAqSCdwK2PZlsG85puUXvcVW0HkHnmj/AA++XDaFVu43f2Cmv7iiMkr2IXaMDTyom0FywFn3KAXwfTLdJNq2HtFSU8SEgNS2N1H04uvh0OT5ex1eUKJtjBtsiSeSRQCLXkAg0TV31GdtZ3f1bxCMLO0UbuY4zEzBdwG5rAFE+1ZDj7IliDPNpWZXG3dKkq0x5DqTXPHyxsbYd29EywqhPhxu7clW8UtXEjnzUKHHAr88dL3HhOn2xsnjFwS5LUEskqo6XVAX+d559sKUA8hPNqTxXup9z/llge0XRxU7FQvAAZRdewo36X/lk1U9LjtPupOteFD4oCHxCfDokfyLd9AOnW85d0uy/G3Rq6RxAeJKDtkDg7aQBuBdH14rpeddN3i1TKq0SspMfl3M7D18O/4h7k8c3747vBKezdJ4FbdTOvNm9qAlWArigOBfW7HQZd/V76VOs7F0Mpb6rqgslnZE9hSQaIFgEA+lX8qzN6/syWBwHAU8kEEFTXWv0yLFF9mZGNBSAoBF2fX4dP0ywE80ap46b438yq5BYj39x+OYbnpxGoWShJw4s7wQHPHSzw//ABc8dTiJO8ZRlrZaglDtD7GDCz1V+nPBFYNBHIfsTRI5RzyPkTwcBK8QMckYI5olabn3JHmX4H8CMbG+719vw6vQBogfFaQIU6SqGVmIbnzISFs8j5ennWg10kLbo3ZDY3FGZWIvlbU8jJUMJ5kiUHggpZY/HYeo6/dPPXqMi6QLvZnRmUdQoBK8+oPH55nTUump7Q7zExvs1UgY/d2s6m+OfhddcpIu8ercrG+plZGKqwZy1ixxzkjT6LTOjORIm2+Cq23HAQAiySQKyp2KJEKqwBZeG4P3hmZjxmnfy+a+bKWyTXx7h9HR+zk/3s1UgzJ/R0Ps5P8AezX7fzz5nl7rt1XAphi8jDPO6JinOerP2b/7p/tjweM5agXG3+6f7Z6HGduPd3RKYIwdpoXW1eP0+OXghXjgflmK7N7zQQoI3lUMooj1B9Qckjvxpr5kXPfjnNTbnn4cuVsjXFBiNt9azMJ330vrIv55z/bLTV+8X/Fm/wBMWfwy+NTSn+2Znv3GRo5FTknYOvoGB/yzmne7SgfvR6+uQ+2u8ujljZPEvdxWJ5Jsvhyn8eYamN6UMLUDih5gOenTi8r1UixuXkCwevHNXVg3mn1LL0WRNvqCetc+mVc0UZNuA3tXpwR6c53/AEx+vL+WfwzQa5Y5IpOUaLYy7SaLKRZPJrcAbr+2a/Wzdn68D62vnC+WUko3X7oYfmAbGZCPSqoBVxYP8YDfgQRRxRGdvGzdfVWINe1f55Mrjf61PHnP4kaj6Pt9ydn6lZQhBpmXcCCdp3Lx6cWADR5yh7Yi1cPiHUxP4h8gkPKBSKZRXHP98tdNqpI/3bOlkMwXgWt7SCOvU9ff1zUaPvaArLPEZCwoslc++5W4/LM7n1eOfx47ljoe1mj8rKsiHqj2f8LdV/DNJ2t3e00paTTyiIkk+FJdD4K3oLvrmXfsuYf+mfwo/wBsnKfWuFv8WcEMUhLQP4T1ZjkI2keoDHg/I4CWRGpvK4pQ1g9B6u3BHHRvfg9Mqx2dL/q2/LLLQz6iPrEHHqHXdY6Vz0GOUOGXxPn7VLp4ZjWOYMvmAUWLIYgEVdXX6ZVdpKRMgYsWtb3CmPm43D0NZZuiMlCMjofDcMVU+vhyDzIfhyMg6nSzNIhILBCArGidoa/MfWsXKVccMpensH0cL9nL882ZTMd9G48kvzGbds+b5Mfb05Ze0VkvDOjLzi5x4ryc74xyDjGVxnROmanZWW1fcmOSRnMjDcboAZz/AGBi/wBY35Zrwc6LnWZ1m5VjP2Ah/nbAdwYf52za4HNcqnOsZ+wUP87Yo7hwfztmpg1iSNIqnmJ9klgim2K/BPUbXU2PfFEyGqZTuG5aYHcOPMvuORz8Ri5ZHOsqO4kH8zYfsFB/M2arxkotuWgaJsUDdUT6G+KxwkXdtsbuu2xde9ZnlV51kh3F0/8AM2KvcbT+7Zo9ZrAhCKpeVlZ1QeoUgFifQWQPjfF500OrjlQSRm1NjoQQVJVlIPIIYEEHkEY3lrZzrODuLp/dsX9hdP7t+eaTTapZC4W7jcxtYrzAAmvcUw5+OdfHQDcXXaehsUfkfXNbyTnWW/YTTe7fni/sLpv6s1KaiM7adTvvZTA7qFnb78YxdbEVZhIhVL3ncKWrB3H0qj+Ry/6TnWY/YXTf1Yg7i6b+r881qOCLBsHoRhWTd+rzrKDuRpv6vzzqncjS+zfnmnC45RlxtS51Xdk9jR6YERg0et5YFMdiHFm2duTLhj2wzHFpEXHgY1BnRRnORvKlGdBjRhm4504YpwAxt5RW6TQSRyTvvQpNJ4lbW3L9lHEFu6P7u7r1rOek7MkjGmp0Pgw+C1qfNYiBZefL+76G+vwy1OFZrlRVN2W5ilj3rUkjSKdp43S+IQ3PPSvTJK6Qidpd1Bk2lRdMRW1ms1YphYAJDAHoMm4ZLlRX6nQsZUmjcKyo0bKylkdWIYdCCGDDg+xYV0If2boRDGUB3FneRieLeR2kc16DcxoegrJmAGN79Cu0+gkQzbZFqV3kX7M7kZkVBzvpq230HXEh7G8NUVJKEUpliBWwoZGVkbnzAl3IIojcOtc2qDHZqWpVXpeyBGYiH/dvLIbH3mmLs1c+UAua68UMjr3fqOeMSGp1kViVsr4jysCvPQeKRt6cXxZu9wy8qOMEZVQpN18/8yT+ZOdBhjqzOlIMXFrDNaQmNbHHEOShmGKcMiuCDjHjEwznItOxRgMM0hcQ4YtZQlYVi4YBiVjsKxoNrADH1hWXQAMW8QYZYHYYDDKgxcTFyyBcTDDKyMTFxMzVhrYYMMMzppwXrgcMMw0UHBjhhlAW4wU4YYiUXziXhhgOvC8MMqC8LwwwpScQNi4YQqnF3YYZYFBxbwwzQLwvDDCFxm7DDIoOGGGB/9k=");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");
        }
    }
}
