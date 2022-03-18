﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Rookie.Ecom.Identity
{
    public static class InitData
    {
        // test users
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "35d08332-a3dc-4e5b-8a35-ffe522ab3d61",
                    Username = "User1",
                    Password = "u123",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Jhon"),
                        new Claim("family_name", "Doe"),
                        new Claim("role", "Admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "979e8d43-7f7d-4a1d-8c2d-59f145c0bfa1",
                    Username = "User2",
                    Password = "u456",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Jane"),
                        new Claim("family_name", "Dae"),
                        new Claim("role", "User")
                    }
                }
            };
        }

        // identity-related resources (scopes)
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "Your role(s)", new List<string>() { "role" }),
                new IdentityResource("UserNames", "Your UserName(s)", new List<string>() { "UserName" }),
                new IdentityResource("UserIds", "Your UserId(s)", new List<string>() { "UserId" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "Rookie.Ecom",
                    ClientId = "rookieecomclient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5001/"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    },
                    ClientSecrets =
                    {
                        new Secret("rookieecomsecret".Sha256())
                    },
                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "https://localhost:5001/"
                    //},
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientName = "Rookie.Ecom.Admin",
                    ClientId = "rookieecom",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5011/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5011/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles", "UserNames", "UserIds"
                    },
                    ClientSecrets =
                    {
                        new Secret("rookieecom".Sha256())
                    },
                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "https://localhost:5011/"
                    //},
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientName = "Rookie.Ecom.Customer",
                    ClientId = "rookieecomcustomer",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5022/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5022/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles", "UserNames", "UserIds"
                    },
                    ClientSecrets =
                    {
                        new Secret("rookieecomcustomersecret".Sha256())
                    },
                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "https://localhost:5022/"
                    //},
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}
