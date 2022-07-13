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

                // interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
            };
    }
}