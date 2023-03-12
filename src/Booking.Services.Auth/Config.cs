using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Booking.Services.Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                // Management API scopes
                new ApiScope("management.read", "Retrieves the meeting room information."),
                new ApiScope("management.create", "Creates the meeting room."),
                new ApiScope("management.update", "Updates the meeting room."),
                new ApiScope("management.delete", "Deletes the meeting room."),

                // Reservation API scopes
                new ApiScope("reservation.read", "Retrieves the meeting room reservation information."),
                new ApiScope("reservation.create", "Reserves a meeting room."),
                new ApiScope("reservation.update", "Updates the reservation."),
                new ApiScope("reservation.delete", "Cancels the reservation."),

                // Audit API scopes
                new ApiScope("audit.query", "Queries the audit information."),
                new ApiScope("audit.insert", "Inserts a audit record.")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("management", "Meeting Room Management API")
                {
                    Scopes = { "management.read", "management.create", "management.update", "management.delete" }
                },
                new ApiResource("reservation", "Meeting Room Reservation API")
                {
                    Scopes = { "reservation.read", "reservation.create", "reservation.update", "reservation.delete" }
                },
                new ApiResource("audit", "Audit API")
                {
                    Scopes = { "audit.query", "audit.insert" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "management.read", "management.create" }
                },

                new Client
                {
                    ClientId = "webApp",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:9200" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "management.read",
                        "management.create"
                    },
                    RedirectUris = { "https://localhost:9200/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:9200/authentication/logout-callback" }
                },

                new Client
                {
                    ClientId = "webAppProd",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "management.read",
                        "management.create"
                    },
                    RedirectUris = { "https://localhost/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost/authentication/logout-callback" }
                }
            };
    }
}