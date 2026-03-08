# Mulkchi Project Audit Report

> **Audit Date:** 2026-03-08  
> **Repository:** ElshodDev/Mulkchi  
> **Stack:** ASP.NET Core (.NET) backend · Angular 19 frontend · SQL Server (LocalDB)

---

```json
{
  "backend": {
    "entities": [
      {
        "name": "User",
        "file": "Mulkchi.Api/Models/Foundations/Users/User.cs",
        "dbSet": "Users",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                   "type": "Guid" },
          { "name": "FirstName",            "type": "string" },
          { "name": "LastName",             "type": "string" },
          { "name": "Email",                "type": "string" },
          { "name": "Phone",                "type": "string" },
          { "name": "PasswordHash",         "type": "string",           "notes": "[JsonIgnore]" },
          { "name": "AvatarUrl",            "type": "string?" },
          { "name": "Bio",                  "type": "string?" },
          { "name": "Address",              "type": "string?" },
          { "name": "DateOfBirth",          "type": "DateTimeOffset?" },
          { "name": "Gender",               "type": "Gender (enum)" },
          { "name": "IsVerified",           "type": "bool" },
          { "name": "Role",                 "type": "UserRole (enum)" },
          { "name": "Badge",                "type": "HostBadge (enum)" },
          { "name": "Rating",               "type": "decimal",          "precision": "18,2" },
          { "name": "ResponseRate",         "type": "decimal",          "precision": "18,2" },
          { "name": "ResponseTimeMinutes",  "type": "int" },
          { "name": "TotalListings",        "type": "int" },
          { "name": "TotalBookings",        "type": "int" },
          { "name": "HostSince",            "type": "DateTimeOffset?" },
          { "name": "PreferredLanguage",    "type": "string?",          "notes": "uz | ru | en" },
          { "name": "CreatedDate",          "type": "DateTimeOffset" },
          { "name": "UpdatedDate",          "type": "DateTimeOffset" },
          { "name": "DeletedDate",          "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Property",
        "file": "Mulkchi.Api/Models/Foundations/Properties/Property.cs",
        "dbSet": "Properties",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                     "type": "Guid" },
          { "name": "Title",                  "type": "string" },
          { "name": "Description",            "type": "string" },
          { "name": "Type",                   "type": "PropertyType (enum)" },
          { "name": "Category",               "type": "PropertyCategory (enum)" },
          { "name": "Status",                 "type": "PropertyStatus (enum)" },
          { "name": "ListingType",            "type": "ListingType (enum)" },
          { "name": "MonthlyRent",            "type": "decimal?",         "precision": "18,2" },
          { "name": "SalePrice",              "type": "decimal?",         "precision": "18,2" },
          { "name": "PricePerNight",          "type": "decimal?",         "precision": "18,2" },
          { "name": "SecurityDeposit",        "type": "decimal?",         "precision": "18,2" },
          { "name": "Area",                   "type": "double" },
          { "name": "NumberOfBedrooms",       "type": "int" },
          { "name": "NumberOfBathrooms",      "type": "int" },
          { "name": "MaxGuests",              "type": "int" },
          { "name": "Region",                 "type": "UzbekistanRegion (enum)" },
          { "name": "City",                   "type": "string" },
          { "name": "District",               "type": "string" },
          { "name": "Address",                "type": "string" },
          { "name": "Mahalla",                "type": "string?" },
          { "name": "Latitude",               "type": "double?" },
          { "name": "Longitude",              "type": "double?" },
          { "name": "HasWifi",                "type": "bool" },
          { "name": "HasParking",             "type": "bool" },
          { "name": "HasPool",                "type": "bool" },
          { "name": "PetsAllowed",            "type": "bool" },
          { "name": "IsInstantBook",          "type": "bool" },
          { "name": "IsVacant",               "type": "bool" },
          { "name": "IsFeatured",             "type": "bool",             "notes": "forced false on POST" },
          { "name": "IsVerified",             "type": "bool",             "notes": "forced false on POST" },
          { "name": "HasMetroNearby",         "type": "bool" },
          { "name": "HasBusStop",             "type": "bool" },
          { "name": "HasMarketNearby",        "type": "bool" },
          { "name": "HasSchoolNearby",        "type": "bool" },
          { "name": "HasHospitalNearby",      "type": "bool" },
          { "name": "DistanceToCityCenter",   "type": "double" },
          { "name": "HasElevator",            "type": "bool" },
          { "name": "HasSecurity",            "type": "bool" },
          { "name": "HasGenerator",           "type": "bool" },
          { "name": "HasGas",                 "type": "bool" },
          { "name": "HasFurniture",           "type": "bool" },
          { "name": "IsRenovated",            "type": "bool" },
          { "name": "HasAirConditioning",     "type": "bool" },
          { "name": "HasHeating",             "type": "bool" },
          { "name": "HasWasher",              "type": "bool" },
          { "name": "HasKitchen",             "type": "bool" },
          { "name": "HasTV",                  "type": "bool" },
          { "name": "HasWorkspace",           "type": "bool" },
          { "name": "IsSelfCheckIn",          "type": "bool" },
          { "name": "IsChildFriendly",        "type": "bool" },
          { "name": "IsAccessible",           "type": "bool" },
          { "name": "AverageRating",          "type": "decimal",          "precision": "18,2", "notes": "forced 0 on POST" },
          { "name": "ViewsCount",             "type": "int",              "notes": "forced 0 on POST; TODO: orchestration increment" },
          { "name": "FavoritesCount",         "type": "int",              "notes": "forced 0 on POST; TODO: orchestration increment" },
          { "name": "HostId",                 "type": "Guid",             "notes": "set from JWT on POST" },
          { "name": "CreatedDate",            "type": "DateTimeOffset" },
          { "name": "UpdatedDate",            "type": "DateTimeOffset" },
          { "name": "DeletedDate",            "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "HomeRequest",
        "file": "Mulkchi.Api/Models/Foundations/HomeRequests/HomeRequest.cs",
        "dbSet": "HomeRequests",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                   "type": "Guid" },
          { "name": "Type",                 "type": "RequestType (enum)" },
          { "name": "Status",               "type": "RequestStatus (enum)" },
          { "name": "CheckInDate",          "type": "DateTimeOffset?" },
          { "name": "CheckOutDate",         "type": "DateTimeOffset?" },
          { "name": "TotalNights",          "type": "int?" },
          { "name": "GuestCount",           "type": "int" },
          { "name": "TotalPrice",           "type": "decimal",          "precision": "18,2" },
          { "name": "Message",              "type": "string?" },
          { "name": "RejectionReason",      "type": "string?" },
          { "name": "CancellationReason",   "type": "string?" },
          { "name": "GuestId",              "type": "Guid" },
          { "name": "HostId",               "type": "Guid" },
          { "name": "PropertyId",           "type": "Guid" },
          { "name": "CreatedDate",          "type": "DateTimeOffset" },
          { "name": "UpdatedDate",          "type": "DateTimeOffset" },
          { "name": "DeletedDate",          "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Payment",
        "file": "Mulkchi.Api/Models/Foundations/Payments/Payment.cs",
        "dbSet": "Payments",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                       "type": "Guid" },
          { "name": "Amount",                   "type": "decimal",    "precision": "18,2" },
          { "name": "PlatformFee",              "type": "decimal",    "precision": "18,2" },
          { "name": "HostReceives",             "type": "decimal",    "precision": "18,2" },
          { "name": "Type",                     "type": "PaymentType (enum)" },
          { "name": "Status",                   "type": "PaymentStatus (enum)" },
          { "name": "Method",                   "type": "PaymentMethod (enum)" },
          { "name": "IsEscrowHeld",             "type": "bool" },
          { "name": "EscrowReleasedAt",         "type": "DateTimeOffset?" },
          { "name": "ExternalTransactionId",    "type": "string?" },
          { "name": "PaymentUrl",               "type": "string?" },
          { "name": "PayerId",                  "type": "Guid",       "notes": "set from JWT on POST" },
          { "name": "ReceiverId",               "type": "Guid" },
          { "name": "HomeRequestId",            "type": "Guid?" },
          { "name": "ContractId",               "type": "Guid?" },
          { "name": "CreatedDate",              "type": "DateTimeOffset" },
          { "name": "UpdatedDate",              "type": "DateTimeOffset" },
          { "name": "DeletedDate",              "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Review",
        "file": "Mulkchi.Api/Models/Foundations/Reviews/Review.cs",
        "dbSet": "Reviews",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                   "type": "Guid" },
          { "name": "OverallRating",        "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "CleanlinessRating",    "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "LocationRating",       "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "ValueRating",          "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "CommunicationRating",  "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "AccuracyRating",       "type": "decimal",    "precision": "18,2",  "validation": "1-5" },
          { "name": "Comment",              "type": "string" },
          { "name": "IsVerifiedStay",       "type": "bool" },
          { "name": "HostResponse",         "type": "string?" },
          { "name": "HostRespondedAt",      "type": "DateTimeOffset?" },
          { "name": "ReviewerId",           "type": "Guid" },
          { "name": "PropertyId",           "type": "Guid" },
          { "name": "HomeRequestId",        "type": "Guid?" },
          { "name": "CreatedDate",          "type": "DateTimeOffset" },
          { "name": "UpdatedDate",          "type": "DateTimeOffset" },
          { "name": "DeletedDate",          "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Message",
        "file": "Mulkchi.Api/Models/Foundations/Messages/Message.cs",
        "dbSet": "Messages",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",             "type": "Guid" },
          { "name": "Content",        "type": "string" },
          { "name": "Type",           "type": "MessageType (enum)" },
          { "name": "IsRead",         "type": "bool" },
          { "name": "ReadAt",         "type": "DateTimeOffset?" },
          { "name": "SenderId",       "type": "Guid" },
          { "name": "ReceiverId",     "type": "Guid" },
          { "name": "PropertyId",     "type": "Guid?" },
          { "name": "HomeRequestId",  "type": "Guid?" },
          { "name": "CreatedDate",    "type": "DateTimeOffset" },
          { "name": "UpdatedDate",    "type": "DateTimeOffset" },
          { "name": "DeletedDate",    "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Notification",
        "file": "Mulkchi.Api/Models/Foundations/Notifications/Notification.cs",
        "dbSet": "Notifications",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",         "type": "Guid" },
          { "name": "TitleUz",    "type": "string",   "validation": "required" },
          { "name": "TitleRu",    "type": "string?" },
          { "name": "TitleEn",    "type": "string?" },
          { "name": "BodyUz",     "type": "string",   "validation": "required" },
          { "name": "BodyRu",     "type": "string?" },
          { "name": "BodyEn",     "type": "string?" },
          { "name": "Type",       "type": "NotificationType (enum)" },
          { "name": "IsRead",     "type": "bool" },
          { "name": "ReadAt",     "type": "DateTimeOffset?" },
          { "name": "ActionUrl",  "type": "string?" },
          { "name": "UserId",     "type": "Guid" },
          { "name": "CreatedDate","type": "DateTimeOffset" },
          { "name": "UpdatedDate","type": "DateTimeOffset" },
          { "name": "DeletedDate","type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "RentalContract",
        "file": "Mulkchi.Api/Models/Foundations/RentalContracts/RentalContract.cs",
        "dbSet": "RentalContracts",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",               "type": "Guid" },
          { "name": "Status",           "type": "ContractStatus (enum)" },
          { "name": "StartDate",        "type": "DateTimeOffset" },
          { "name": "EndDate",          "type": "DateTimeOffset" },
          { "name": "MonthlyRent",      "type": "decimal",    "precision": "18,2" },
          { "name": "SecurityDeposit",  "type": "decimal",    "precision": "18,2" },
          { "name": "Terms",            "type": "string?" },
          { "name": "DocumentUrl",      "type": "string?" },
          { "name": "IsSigned",         "type": "bool" },
          { "name": "SignedAt",         "type": "DateTimeOffset?" },
          { "name": "TenantId",         "type": "Guid" },
          { "name": "LandlordId",       "type": "Guid" },
          { "name": "PropertyId",       "type": "Guid" },
          { "name": "HomeRequestId",    "type": "Guid?" },
          { "name": "CreatedDate",      "type": "DateTimeOffset" },
          { "name": "UpdatedDate",      "type": "DateTimeOffset" },
          { "name": "DeletedDate",      "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Favorite",
        "file": "Mulkchi.Api/Models/Foundations/Favorites/Favorite.cs",
        "dbSet": "Favorites",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",           "type": "Guid" },
          { "name": "UserId",       "type": "Guid" },
          { "name": "PropertyId",   "type": "Guid" },
          { "name": "CreatedDate",  "type": "DateTimeOffset" },
          { "name": "UpdatedDate",  "type": "DateTimeOffset" },
          { "name": "DeletedDate",  "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "PropertyImage",
        "file": "Mulkchi.Api/Models/Foundations/PropertyImages/PropertyImage.cs",
        "dbSet": "PropertyImages",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",           "type": "Guid" },
          { "name": "Url",          "type": "string" },
          { "name": "Caption",      "type": "string?" },
          { "name": "SortOrder",    "type": "int" },
          { "name": "IsPrimary",    "type": "bool" },
          { "name": "PropertyId",   "type": "Guid" },
          { "name": "CreatedDate",  "type": "DateTimeOffset" },
          { "name": "UpdatedDate",  "type": "DateTimeOffset" },
          { "name": "DeletedDate",  "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "PropertyView",
        "file": "Mulkchi.Api/Models/Foundations/PropertyViews/PropertyView.cs",
        "dbSet": "PropertyViews",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",           "type": "Guid" },
          { "name": "IpAddress",    "type": "string?" },
          { "name": "UserAgent",    "type": "string?" },
          { "name": "PropertyId",   "type": "Guid" },
          { "name": "UserId",       "type": "Guid?" },
          { "name": "CreatedDate",  "type": "DateTimeOffset" },
          { "name": "UpdatedDate",  "type": "DateTimeOffset" },
          { "name": "DeletedDate",  "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "SavedSearch",
        "file": "Mulkchi.Api/Models/Foundations/SavedSearches/SavedSearch.cs",
        "dbSet": "SavedSearches",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",             "type": "Guid" },
          { "name": "Name",           "type": "string" },
          { "name": "SearchQuery",    "type": "string" },
          { "name": "NotifyOnMatch",  "type": "bool" },
          { "name": "UserId",         "type": "Guid" },
          { "name": "CreatedDate",    "type": "DateTimeOffset" },
          { "name": "UpdatedDate",    "type": "DateTimeOffset" },
          { "name": "DeletedDate",    "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Discount",
        "file": "Mulkchi.Api/Models/Foundations/Discounts/Discount.cs",
        "dbSet": "Discounts",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",                 "type": "Guid" },
          { "name": "Code",               "type": "string" },
          { "name": "Description",        "type": "string?" },
          { "name": "Type",               "type": "DiscountType (enum)" },
          { "name": "Target",             "type": "DiscountTarget (enum)" },
          { "name": "Value",              "type": "decimal",  "precision": "18,2" },
          { "name": "MaxDiscountAmount",  "type": "decimal?", "precision": "18,2" },
          { "name": "MaxUsageCount",      "type": "int?" },
          { "name": "UsageCount",         "type": "int" },
          { "name": "StartsAt",           "type": "DateTimeOffset?" },
          { "name": "ExpiresAt",          "type": "DateTimeOffset?" },
          { "name": "IsActive",           "type": "bool" },
          { "name": "PropertyId",         "type": "Guid?" },
          { "name": "UserId",             "type": "Guid?" },
          { "name": "CreatedDate",        "type": "DateTimeOffset" },
          { "name": "UpdatedDate",        "type": "DateTimeOffset" },
          { "name": "DeletedDate",        "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "DiscountUsage",
        "file": "Mulkchi.Api/Models/Foundations/Discounts/DiscountUsage.cs",
        "dbSet": "DiscountUsages",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",             "type": "Guid" },
          { "name": "DiscountId",     "type": "Guid" },
          { "name": "UserId",         "type": "Guid" },
          { "name": "HomeRequestId",  "type": "Guid?" },
          { "name": "AmountSaved",    "type": "decimal",  "precision": "18,2" },
          { "name": "CreatedDate",    "type": "DateTimeOffset" },
          { "name": "UpdatedDate",    "type": "DateTimeOffset" },
          { "name": "DeletedDate",    "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "AiRecommendation",
        "file": "Mulkchi.Api/Models/Foundations/AIs/AiRecommendation.cs",
        "dbSet": "AiRecommendations",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",             "type": "Guid" },
          { "name": "Type",           "type": "AiRecommendationType (enum)" },
          { "name": "Title",          "type": "string" },
          { "name": "Description",    "type": "string?" },
          { "name": "Score",          "type": "decimal",  "precision": "18,2" },
          { "name": "Metadata",       "type": "string?",  "notes": "unstructured JSON string" },
          { "name": "IsActedUpon",    "type": "bool" },
          { "name": "UserId",         "type": "Guid" },
          { "name": "PropertyId",     "type": "Guid?" },
          { "name": "CreatedDate",    "type": "DateTimeOffset" },
          { "name": "UpdatedDate",    "type": "DateTimeOffset" },
          { "name": "DeletedDate",    "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "Announcement",
        "file": "Mulkchi.Api/Models/Foundations/Announcements/Announcement.cs",
        "dbSet": "Announcements",
        "softDelete": true,
        "queryFilter": "e.DeletedDate == null",
        "fields": [
          { "name": "Id",           "type": "Guid" },
          { "name": "TitleUz",      "type": "string",   "validation": "required" },
          { "name": "TitleRu",      "type": "string?" },
          { "name": "TitleEn",      "type": "string?" },
          { "name": "ContentUz",    "type": "string",   "validation": "required" },
          { "name": "ContentRu",    "type": "string?" },
          { "name": "ContentEn",    "type": "string?" },
          { "name": "Type",         "type": "AnnouncementType (enum)" },
          { "name": "Target",       "type": "AnnouncementTarget (enum)" },
          { "name": "IsActive",     "type": "bool" },
          { "name": "PublishedAt",  "type": "DateTimeOffset?" },
          { "name": "ExpiresAt",    "type": "DateTimeOffset?" },
          { "name": "CreatedBy",    "type": "Guid" },
          { "name": "CreatedDate",  "type": "DateTimeOffset" },
          { "name": "UpdatedDate",  "type": "DateTimeOffset" },
          { "name": "DeletedDate",  "type": "DateTimeOffset?" }
        ]
      },
      {
        "name": "UserRefreshToken",
        "file": "Mulkchi.Api/Models/Foundations/Auth/UserRefreshToken.cs",
        "dbSet": "UserRefreshTokens",
        "softDelete": false,
        "queryFilter": "e.ExpiresAt > DateTimeOffset.UtcNow",
        "fields": [
          { "name": "Id",           "type": "Guid" },
          { "name": "Token",        "type": "string",   "notes": "64-byte cryptographically random base64" },
          { "name": "UserId",       "type": "Guid" },
          { "name": "ExpiresAt",    "type": "DateTimeOffset",   "notes": "AccessToken expiry × 2" },
          { "name": "IsRevoked",    "type": "bool" },
          { "name": "CreatedDate",  "type": "DateTimeOffset" }
        ]
      }
    ],

    "commonModels": {
      "PagedResult<T>": {
        "file": "Mulkchi.Api/Models/Foundations/Common/PagedResult.cs",
        "fields": [
          { "name": "Items",          "type": "IEnumerable<T>" },
          { "name": "TotalCount",     "type": "int" },
          { "name": "Page",           "type": "int" },
          { "name": "PageSize",       "type": "int" },
          { "name": "TotalPages",     "type": "int (calculated: ceil(TotalCount/PageSize))" },
          { "name": "HasNextPage",    "type": "bool (calculated: Page < TotalPages)" },
          { "name": "HasPreviousPage","type": "bool (calculated: Page > 1)" }
        ]
      },
      "PaginationParams": {
        "file": "Mulkchi.Api/Models/Foundations/Common/PaginationParams.cs",
        "fields": [
          { "name": "Page",     "type": "int", "default": 1, "min": 1 },
          { "name": "PageSize", "type": "int", "default": 20, "min": 1, "max": 100 }
        ]
      },
      "LoginRequest": {
        "fields": ["string Email", "string Password"]
      },
      "RegisterRequest": {
        "fields": ["string FirstName", "string LastName", "string Email", "string Phone", "string Password", "string PreferredLanguage"]
      },
      "AuthResponse": {
        "fields": ["string Token", "string RefreshToken", "DateTimeOffset ExpiresAt", "Guid UserId", "string Email", "UserRole Role"]
      }
    },

    "endpoints": [
      {
        "controller": "AuthController",
        "baseRoute": "api/auth",
        "actions": [
          { "method": "POST", "route": "api/auth/login",   "auth": "none",        "description": "Login with email+password, returns JWT+refresh token" },
          { "method": "POST", "route": "api/auth/register","auth": "none",        "description": "Register new user (role=Guest), returns JWT+refresh token" },
          { "method": "POST", "route": "api/auth/refresh", "auth": "none",        "description": "Exchange refresh token for new JWT pair (old token revoked)" },
          { "method": "POST", "route": "api/auth/logout",  "auth": "[Authorize]", "description": "Revoke refresh token" }
        ]
      },
      {
        "controller": "UsersController",
        "baseRoute": "api/users",
        "actions": [
          { "method": "GET",    "route": "api/users",     "auth": "[Authorize(Roles='Admin')]",       "description": "List all users (paginated)" },
          { "method": "GET",    "route": "api/users/{id}","auth": "[Authorize] (self or admin)",       "description": "Get user by id" },
          { "method": "PUT",    "route": "api/users",     "auth": "[Authorize] (self or admin)",       "description": "Update user" },
          { "method": "DELETE", "route": "api/users/{id}","auth": "[Authorize(Roles='Admin')]",        "description": "Soft-delete user by id" }
        ]
      },
      {
        "controller": "PropertiesController",
        "baseRoute": "api/properties",
        "actions": [
          { "method": "POST",   "route": "api/properties",     "auth": "[Authorize(Roles='Host,Admin')]", "description": "Create property; sets HostId from JWT, IsFeatured/IsVerified=false, AverageRating/ViewsCount/FavoritesCount=0" },
          { "method": "GET",    "route": "api/properties",     "auth": "[AllowAnonymous]",                "description": "List properties with filters: city, minPrice, maxPrice, bedrooms, region, listingType + pagination" },
          { "method": "GET",    "route": "api/properties/{id}","auth": "[AllowAnonymous]",                "description": "Get property by id" },
          { "method": "PUT",    "route": "api/properties",     "auth": "[Authorize(Roles='Host,Admin')]", "description": "Update property (Host: own only; Admin: any)" },
          { "method": "DELETE", "route": "api/properties/{id}","auth": "[Authorize(Roles='Host,Admin')]", "description": "Soft-delete property" }
        ]
      },
      {
        "controller": "HomeRequestsController",
        "baseRoute": "api/homerequests",
        "actions": [
          { "method": "POST",   "route": "api/homerequests",      "auth": "[Authorize]", "description": "Create booking/inquiry request" },
          { "method": "GET",    "route": "api/homerequests",      "auth": "[Authorize]", "description": "List home requests (paginated)" },
          { "method": "GET",    "route": "api/homerequests/{id}", "auth": "[Authorize]", "description": "Get home request by id" },
          { "method": "PUT",    "route": "api/homerequests",      "auth": "[Authorize]", "description": "Update home request" },
          { "method": "DELETE", "route": "api/homerequests/{id}", "auth": "[Authorize]", "description": "Soft-delete home request" }
        ]
      },
      {
        "controller": "PaymentsController",
        "baseRoute": "api/payments",
        "actions": [
          { "method": "POST",   "route": "api/payments",      "auth": "[Authorize]", "description": "Create payment; sets PayerId from JWT" },
          { "method": "GET",    "route": "api/payments",      "auth": "[Authorize]", "description": "List payments (paginated); Admin sees all, user sees own (payer or receiver)" },
          { "method": "GET",    "route": "api/payments/{id}", "auth": "[Authorize]", "description": "Get payment by id" },
          { "method": "PUT",    "route": "api/payments",      "auth": "[Authorize]", "description": "Update payment" },
          { "method": "DELETE", "route": "api/payments/{id}", "auth": "[Authorize]", "description": "Soft-delete payment" }
        ]
      },
      {
        "controller": "ReviewsController",
        "baseRoute": "api/reviews",
        "actions": [
          { "method": "POST",   "route": "api/reviews",      "auth": "[Authorize]",       "description": "Create review" },
          { "method": "GET",    "route": "api/reviews",      "auth": "[AllowAnonymous]",  "description": "List reviews (paginated)" },
          { "method": "GET",    "route": "api/reviews/{id}", "auth": "[AllowAnonymous]",  "description": "Get review by id" },
          { "method": "PUT",    "route": "api/reviews",      "auth": "[Authorize]",       "description": "Update review" },
          { "method": "DELETE", "route": "api/reviews/{id}", "auth": "[Authorize]",       "description": "Soft-delete review" }
        ]
      },
      {
        "controller": "MessagesController",
        "baseRoute": "api/messages",
        "actions": [
          { "method": "POST",   "route": "api/messages",      "auth": "[Authorize]", "description": "Create message (REST; prefer SignalR for real-time)" },
          { "method": "GET",    "route": "api/messages",      "auth": "[Authorize]", "description": "List messages (paginated)" },
          { "method": "GET",    "route": "api/messages/{id}", "auth": "[Authorize]", "description": "Get message by id" },
          { "method": "PUT",    "route": "api/messages",      "auth": "[Authorize]", "description": "Update message" },
          { "method": "DELETE", "route": "api/messages/{id}", "auth": "[Authorize]", "description": "Soft-delete message" }
        ]
      },
      {
        "controller": "NotificationsController",
        "baseRoute": "api/notifications",
        "actions": [
          { "method": "POST",   "route": "api/notifications",      "auth": "[Authorize]", "description": "Create notification" },
          { "method": "GET",    "route": "api/notifications",      "auth": "[Authorize]", "description": "List notifications (paginated)" },
          { "method": "GET",    "route": "api/notifications/{id}", "auth": "[Authorize]", "description": "Get notification by id" },
          { "method": "PUT",    "route": "api/notifications",      "auth": "[Authorize]", "description": "Update notification" },
          { "method": "DELETE", "route": "api/notifications/{id}", "auth": "[Authorize]", "description": "Soft-delete notification" }
        ]
      },
      {
        "controller": "FavoritesController",
        "baseRoute": "api/favorites",
        "actions": [
          { "method": "POST",   "route": "api/favorites",      "auth": "[Authorize]", "description": "Add to favorites (duplicate guard: throws if same UserId+PropertyId already exists)" },
          { "method": "GET",    "route": "api/favorites",      "auth": "[Authorize]", "description": "List favorites (paginated)" },
          { "method": "GET",    "route": "api/favorites/{id}", "auth": "[Authorize]", "description": "Get favorite by id" },
          { "method": "PUT",    "route": "api/favorites",      "auth": "[Authorize]", "description": "Update favorite" },
          { "method": "DELETE", "route": "api/favorites/{id}", "auth": "[Authorize]", "description": "Soft-delete favorite" }
        ]
      },
      {
        "controller": "SavedSearchesController",
        "baseRoute": "api/savedsearches",
        "actions": [
          { "method": "POST",   "route": "api/savedsearches",      "auth": "[Authorize]", "description": "Save a search" },
          { "method": "GET",    "route": "api/savedsearches",      "auth": "[Authorize]", "description": "List saved searches (paginated)" },
          { "method": "GET",    "route": "api/savedsearches/{id}", "auth": "[Authorize]", "description": "Get saved search by id" },
          { "method": "PUT",    "route": "api/savedsearches",      "auth": "[Authorize]", "description": "Update saved search" },
          { "method": "DELETE", "route": "api/savedsearches/{id}", "auth": "[Authorize]", "description": "Soft-delete saved search" }
        ]
      },
      {
        "controller": "PropertyImagesController",
        "baseRoute": "api/propertyimages",
        "actions": [
          { "method": "POST",   "route": "api/propertyimages",      "auth": "[Authorize]", "description": "Add image URL to property" },
          { "method": "GET",    "route": "api/propertyimages",      "auth": "[Authorize]", "description": "List property images (paginated)" },
          { "method": "GET",    "route": "api/propertyimages/{id}", "auth": "[Authorize]", "description": "Get image by id" },
          { "method": "PUT",    "route": "api/propertyimages",      "auth": "[Authorize]", "description": "Update image" },
          { "method": "DELETE", "route": "api/propertyimages/{id}", "auth": "[Authorize]", "description": "Soft-delete image" }
        ]
      },
      {
        "controller": "PropertyViewsController",
        "baseRoute": "api/propertyviews",
        "actions": [
          { "method": "POST",   "route": "api/propertyviews",      "auth": "[Authorize]", "description": "Record a property view (dedup by IP per day); TODO: increment Property.ViewsCount via orchestration" },
          { "method": "GET",    "route": "api/propertyviews",      "auth": "[Authorize]", "description": "List property views (paginated)" },
          { "method": "GET",    "route": "api/propertyviews/{id}", "auth": "[Authorize]", "description": "Get view by id" },
          { "method": "PUT",    "route": "api/propertyviews",      "auth": "[Authorize]", "description": "Update view" },
          { "method": "DELETE", "route": "api/propertyviews/{id}", "auth": "[Authorize]", "description": "Soft-delete view" }
        ]
      },
      {
        "controller": "RentalContractsController",
        "baseRoute": "api/rentalcontracts",
        "actions": [
          { "method": "POST",   "route": "api/rentalcontracts",      "auth": "[Authorize]", "description": "Create rental contract" },
          { "method": "GET",    "route": "api/rentalcontracts",      "auth": "[Authorize]", "description": "List rental contracts (paginated)" },
          { "method": "GET",    "route": "api/rentalcontracts/{id}", "auth": "[Authorize]", "description": "Get contract by id" },
          { "method": "PUT",    "route": "api/rentalcontracts",      "auth": "[Authorize]", "description": "Update contract" },
          { "method": "DELETE", "route": "api/rentalcontracts/{id}", "auth": "[Authorize]", "description": "Soft-delete contract" }
        ]
      },
      {
        "controller": "DiscountsController",
        "baseRoute": "api/discounts",
        "actions": [
          { "method": "POST",   "route": "api/discounts",      "auth": "[Authorize(Roles='Admin,Host')]", "description": "Create discount code" },
          { "method": "GET",    "route": "api/discounts",      "auth": "[AllowAnonymous]",                "description": "List discounts (paginated)" },
          { "method": "GET",    "route": "api/discounts/{id}", "auth": "[AllowAnonymous]",                "description": "Get discount by id" },
          { "method": "PUT",    "route": "api/discounts",      "auth": "[Authorize(Roles='Admin,Host')]", "description": "Update discount" },
          { "method": "DELETE", "route": "api/discounts/{id}", "auth": "[Authorize(Roles='Admin,Host')]", "description": "Soft-delete discount" }
        ]
      },
      {
        "controller": "DiscountUsagesController",
        "baseRoute": "api/discountusages",
        "actions": [
          { "method": "POST",   "route": "api/discountusages",      "auth": "[Authorize]", "description": "Record discount usage" },
          { "method": "GET",    "route": "api/discountusages",      "auth": "[Authorize]", "description": "List discount usages (paginated)" },
          { "method": "GET",    "route": "api/discountusages/{id}", "auth": "[Authorize]", "description": "Get usage by id" },
          { "method": "PUT",    "route": "api/discountusages",      "auth": "[Authorize]", "description": "Update discount usage" },
          { "method": "DELETE", "route": "api/discountusages/{id}", "auth": "[Authorize]", "description": "Soft-delete discount usage" }
        ]
      },
      {
        "controller": "AiRecommendationsController",
        "baseRoute": "api/airecommendations",
        "actions": [
          { "method": "POST",   "route": "api/airecommendations",      "auth": "[Authorize]", "description": "Create AI recommendation" },
          { "method": "GET",    "route": "api/airecommendations",      "auth": "[Authorize]", "description": "List AI recommendations (paginated)" },
          { "method": "GET",    "route": "api/airecommendations/{id}", "auth": "[Authorize]", "description": "Get recommendation by id" },
          { "method": "PUT",    "route": "api/airecommendations",      "auth": "[Authorize]", "description": "Update recommendation" },
          { "method": "DELETE", "route": "api/airecommendations/{id}", "auth": "[Authorize]", "description": "Soft-delete recommendation" }
        ]
      },
      {
        "controller": "AnnouncementsController",
        "baseRoute": "api/announcements",
        "actions": [
          { "method": "POST",   "route": "api/announcements",      "auth": "[Authorize]", "description": "Create announcement" },
          { "method": "GET",    "route": "api/announcements",      "auth": "[AllowAnonymous]", "description": "List announcements (paginated)" },
          { "method": "GET",    "route": "api/announcements/{id}", "auth": "[AllowAnonymous]", "description": "Get announcement by id" },
          { "method": "PUT",    "route": "api/announcements",      "auth": "[Authorize]",      "description": "Update announcement" },
          { "method": "DELETE", "route": "api/announcements/{id}", "auth": "[Authorize]",      "description": "Soft-delete announcement" }
        ]
      }
    ],

    "relationships": [
      { "from": "Property",         "to": "User",           "via": "Property.HostId",           "type": "FK (logical, no EF navigation)" },
      { "from": "HomeRequest",      "to": "User",           "via": "HomeRequest.GuestId",        "type": "FK (logical)" },
      { "from": "HomeRequest",      "to": "User",           "via": "HomeRequest.HostId",         "type": "FK (logical)" },
      { "from": "HomeRequest",      "to": "Property",       "via": "HomeRequest.PropertyId",     "type": "FK (logical)" },
      { "from": "Payment",          "to": "User",           "via": "Payment.PayerId",            "type": "FK (logical)" },
      { "from": "Payment",          "to": "User",           "via": "Payment.ReceiverId",         "type": "FK (logical)" },
      { "from": "Payment",          "to": "HomeRequest",    "via": "Payment.HomeRequestId",      "type": "optional FK" },
      { "from": "Payment",          "to": "RentalContract", "via": "Payment.ContractId",         "type": "optional FK" },
      { "from": "Review",           "to": "User",           "via": "Review.ReviewerId",          "type": "FK (logical)" },
      { "from": "Review",           "to": "Property",       "via": "Review.PropertyId",          "type": "FK (logical)" },
      { "from": "Review",           "to": "HomeRequest",    "via": "Review.HomeRequestId",       "type": "optional FK" },
      { "from": "Message",          "to": "User",           "via": "Message.SenderId",           "type": "FK (logical)" },
      { "from": "Message",          "to": "User",           "via": "Message.ReceiverId",         "type": "FK (logical)" },
      { "from": "Message",          "to": "Property",       "via": "Message.PropertyId",         "type": "optional FK" },
      { "from": "Message",          "to": "HomeRequest",    "via": "Message.HomeRequestId",      "type": "optional FK" },
      { "from": "Notification",     "to": "User",           "via": "Notification.UserId",        "type": "FK (logical)" },
      { "from": "RentalContract",   "to": "User",           "via": "RentalContract.TenantId",    "type": "FK (logical)" },
      { "from": "RentalContract",   "to": "User",           "via": "RentalContract.LandlordId",  "type": "FK (logical)" },
      { "from": "RentalContract",   "to": "Property",       "via": "RentalContract.PropertyId",  "type": "FK (logical)" },
      { "from": "RentalContract",   "to": "HomeRequest",    "via": "RentalContract.HomeRequestId","type": "optional FK" },
      { "from": "Favorite",         "to": "User",           "via": "Favorite.UserId",            "type": "FK (logical)" },
      { "from": "Favorite",         "to": "Property",       "via": "Favorite.PropertyId",        "type": "FK (logical)" },
      { "from": "PropertyImage",    "to": "Property",       "via": "PropertyImage.PropertyId",   "type": "FK (logical)" },
      { "from": "PropertyView",     "to": "Property",       "via": "PropertyView.PropertyId",    "type": "FK (logical)" },
      { "from": "PropertyView",     "to": "User",           "via": "PropertyView.UserId",        "type": "optional FK" },
      { "from": "SavedSearch",      "to": "User",           "via": "SavedSearch.UserId",         "type": "FK (logical)" },
      { "from": "Discount",         "to": "Property",       "via": "Discount.PropertyId",        "type": "optional FK" },
      { "from": "Discount",         "to": "User",           "via": "Discount.UserId",            "type": "optional FK" },
      { "from": "DiscountUsage",    "to": "Discount",       "via": "DiscountUsage.DiscountId",   "type": "FK (logical)" },
      { "from": "DiscountUsage",    "to": "User",           "via": "DiscountUsage.UserId",       "type": "FK (logical)" },
      { "from": "DiscountUsage",    "to": "HomeRequest",    "via": "DiscountUsage.HomeRequestId","type": "optional FK" },
      { "from": "AiRecommendation", "to": "User",           "via": "AiRecommendation.UserId",    "type": "FK (logical)" },
      { "from": "AiRecommendation", "to": "Property",       "via": "AiRecommendation.PropertyId","type": "optional FK" },
      { "from": "Announcement",     "to": "User",           "via": "Announcement.CreatedBy",     "type": "FK (logical)" },
      { "from": "UserRefreshToken", "to": "User",           "via": "UserRefreshToken.UserId",    "type": "FK (logical)" },
      {
        "notes": "No EF navigation properties defined on any entity. All relationships are logical (Guid FK fields only). No cascade-delete rules configured. EF global query filters prevent seeing soft-deleted rows."
      }
    ],

    "jwtTokenStructure": {
      "algorithm": "HMAC-SHA256",
      "keySource": "JwtSettings:Secret (UTF-8 encoded symmetric key)",
      "issuer": "JwtSettings:Issuer (appsettings: 'Mulkchi')",
      "audience": "JwtSettings:Audience (appsettings: 'MulkchiUsers')",
      "accessTokenExpiry": "JwtSettings:ExpiryDays days (default: 7 days)",
      "refreshTokenExpiry": "ExpiryDays × 2 (default: 14 days)",
      "clockSkew": "TimeSpan.Zero (no tolerance)",
      "claims": [
        { "type": "ClaimTypes.NameIdentifier (sub)", "value": "user.Id.ToString()" },
        { "type": "ClaimTypes.Email",                "value": "user.Email" },
        { "type": "ClaimTypes.Role",                 "value": "user.Role.ToString() — 'Guest' | 'Host' | 'Admin'" },
        { "type": "JwtRegisteredClaimNames.Jti",     "value": "Guid.NewGuid().ToString()" }
      ],
      "signalRSupport": "OnMessageReceived reads 'access_token' query param for requests to '/hub'",
      "refreshToken": {
        "format": "64 cryptographically random bytes encoded as base64 string",
        "storage": "UserRefreshTokens table",
        "revocation": "IsRevoked = true on logout or refresh"
      }
    },

    "validationRules": {
      "LoginRequest": [
        "Email: required (non-empty)",
        "Password: required (non-empty)"
      ],
      "RegisterRequest": [
        "FirstName: required (non-empty)",
        "LastName: required (non-empty)",
        "Email: required + must contain '@' and '.'",
        "Phone: required (non-empty)",
        "Password: required + length >= 8 + has uppercase + has lowercase + has digit"
      ],
      "User (Add)": [
        "Id: not Guid.Empty",
        "FirstName: not null/empty/whitespace",
        "LastName: not null/empty/whitespace",
        "Email: not null/empty/whitespace",
        "Phone: not null/empty/whitespace",
        "PasswordHash: not null/empty/whitespace"
      ],
      "User (Modify)": [
        "Id: not Guid.Empty",
        "FirstName, LastName, Email, Phone: not null/empty/whitespace"
      ],
      "Property (Add/Modify)": [
        "Id: not Guid.Empty",
        "Title: not null/empty/whitespace",
        "Description: not null/empty/whitespace",
        "City: not null/empty/whitespace",
        "Address: not null/empty/whitespace"
      ],
      "HomeRequest (Add/Modify)": [
        "Id: not Guid.Empty",
        "GuestId: not Guid.Empty",
        "HostId: not Guid.Empty",
        "PropertyId: not Guid.Empty",
        "GuestCount: > 0",
        "TotalPrice: >= 0"
      ],
      "Payment (Add/Modify)": [
        "Id: not Guid.Empty",
        "PayerId: not Guid.Empty",
        "ReceiverId: not Guid.Empty",
        "Amount: > 0"
      ],
      "Review (Add/Modify)": [
        "Id: not Guid.Empty",
        "ReviewerId: not Guid.Empty",
        "PropertyId: not Guid.Empty",
        "Comment: not null/empty/whitespace",
        "OverallRating: between 1 and 5 (inclusive)",
        "CleanlinessRating: between 1 and 5",
        "LocationRating: between 1 and 5",
        "ValueRating: between 1 and 5",
        "CommunicationRating: between 1 and 5",
        "AccuracyRating: between 1 and 5"
      ],
      "Notification (Add)": [
        "TitleUz: required",
        "BodyUz: required"
      ],
      "Announcement (Add)": [
        "TitleUz: required",
        "ContentUz: required"
      ],
      "RentalContract (Add/Modify)": [
        "Id: not Guid.Empty",
        "TenantId: not Guid.Empty",
        "LandlordId: not Guid.Empty",
        "PropertyId: not Guid.Empty",
        "MonthlyRent: > 0",
        "StartDate: valid",
        "EndDate: valid"
      ],
      "Favorite (Add)": [
        "Id: not Guid.Empty",
        "UserId: not Guid.Empty",
        "PropertyId: not Guid.Empty",
        "Duplicate guard: AlreadyExistsFavoriteException if same UserId+PropertyId exists"
      ]
    },

    "businessLogic": {
      "AuthService": [
        "Register: new user always assigned Role=Guest",
        "Register: BCrypt.HashPassword used for PasswordHash",
        "Register/Login: GenerateAndSaveAuthResponseAsync creates JWT + refresh token and persists to DB",
        "Refresh: old refresh token revoked (IsRevoked=true) before issuing new pair",
        "Logout: refresh token revoked; no-op if already revoked"
      ],
      "PropertyService (Controller)": [
        "POST: HostId set from JWT ClaimTypes.NameIdentifier",
        "POST: IsFeatured=false, IsVerified=false forced",
        "POST: AverageRating=0, ViewsCount=0, FavoritesCount=0 forced",
        "PUT: Non-admin Host can only modify own properties (HostId check)",
        "GET: Server-side filtering: city (exact match), minPrice/maxPrice (MonthlyRent OR SalePrice OR PricePerNight), bedrooms (exact), region (enum), listingType (enum)"
      ],
      "PaymentService (Controller)": [
        "POST: PayerId set from JWT",
        "GET: Admin sees all payments; other users see only payments where PayerId or ReceiverId matches"
      ],
      "FavoriteService": [
        "Add: Duplicate guard — throws AlreadyExistsFavoriteException mapped to FavoriteDependencyValidationException if same UserId+PropertyId already exists (active)"
      ],
      "All Add*Async services": [
        "CreatedDate and UpdatedDate set via IDateTimeBroker.GetCurrentDateTimeOffset()"
      ],
      "All Modify*Async services": [
        "UpdatedDate stamped via IDateTimeBroker before calling storage broker"
      ],
      "All Delete*ByIdAsync brokers (soft-delete entities)": [
        "Sets DeletedDate=DateTimeOffset.UtcNow and UpdatedDate=DateTimeOffset.UtcNow",
        "Uses EntityState.Modified (not Remove)"
      ],
      "ChatHub (SignalR)": [
        "SendMessage: saves message to DB, sends 'ReceiveMessage' to receiver, 'MessageSent' to caller",
        "MarkAsRead: updates IsRead=true, ReadAt=now, sends 'MessageRead' event to original sender"
      ],
      "TODOs (not implemented)": [
        "Property.ViewsCount increment: comment 'should be handled by Orchestration service'",
        "Property.FavoritesCount increment: comment 'should be handled by Orchestration service'",
        "Property.AverageRating recalculation: not triggered on Review create/update"
      ]
    },

    "enums": [
      { "name": "UserRole",             "values": ["Guest", "Host", "Admin"] },
      { "name": "Gender",               "values": ["Male", "Female", "Other", "PreferNotToSay"] },
      { "name": "HostBadge",            "values": ["None", "NewHost", "SuperHost", "PremiumHost"] },
      { "name": "PropertyType",         "values": ["Apartment", "House", "Villa", "Room", "Office", "Land", "Commercial"] },
      { "name": "PropertyCategory",     "values": ["Residential", "Commercial", "Industrial", "Agricultural"] },
      { "name": "PropertyStatus",       "values": ["Active", "Inactive", "Pending", "Rejected", "Deleted"] },
      { "name": "ListingType",          "values": ["Rent", "Sale", "ShortTermRent"] },
      { "name": "UzbekistanRegion",     "values": ["ToshkentShahar", "ToshkentViloyat", "Samarqand", "Buxoro", "Andijon", "Fargona", "Namangan", "Qashqadaryo", "Surxondaryo", "Xorazm", "Navoiy", "Jizzax", "Sirdaryo", "Qoraqalpogiston"] },
      { "name": "RequestType",          "values": ["Booking", "Inquiry", "ShortTermRent"] },
      { "name": "RequestStatus",        "values": ["Pending", "Approved", "Rejected", "Cancelled", "Completed"] },
      { "name": "PaymentType",          "values": ["BookingPayment", "SecurityDeposit", "Refund", "PlatformFee"] },
      { "name": "PaymentStatus",        "values": ["Pending", "Processing", "Completed", "Failed", "Refunded", "Cancelled"] },
      { "name": "PaymentMethod",        "values": ["Payme", "Click", "Uzcard", "Humo", "Cash"] },
      { "name": "MessageType",          "values": ["Text", "Image", "File", "System"] },
      { "name": "NotificationType",     "values": ["BookingRequest", "BookingApproved", "BookingRejected", "PaymentReceived", "NewMessage", "ReviewReceived", "SystemAlert"] },
      { "name": "ContractStatus",       "values": ["Draft", "Pending", "Active", "Expired", "Terminated", "Cancelled"] },
      { "name": "DiscountType",         "values": ["Percentage", "FixedAmount"] },
      { "name": "DiscountTarget",       "values": ["AllProperties", "SpecificProperty", "SpecificUser", "FirstBooking"] },
      { "name": "AnnouncementType",     "values": ["General", "Maintenance", "Promotion", "PolicyUpdate"] },
      { "name": "AnnouncementTarget",   "values": ["AllUsers", "Hosts", "Guests", "Admins"] },
      { "name": "AiRecommendationType","values": ["PersonalizedListing", "SimilarProperty", "PriceOptimization", "MarketInsight"] },
      {
        "notes": "Enums serialized as integers (numeric) by default; no JsonStringEnumConverter configured in AddControllers()"
      }
    ],

    "connectionString": {
      "format": "Server=(localdb)\\mssqllocaldb;Database=MulkchiDb;Trusted_Connection=True;MultipleActiveResultSets=true",
      "configKey": "ConnectionStrings:DefaultConnection",
      "configFile": "Mulkchi.Api/appsettings.json",
      "notes": "Auto-migration runs in StorageBroker constructor unless IWebHostEnvironment.IsEnvironment('DesignTime')"
    },

    "signalR": {
      "hubClass": "ChatHub",
      "file": "Mulkchi.Api/Hubs/ChatHub.cs",
      "route": "/hub",
      "authorization": "[Authorize] (JWT required)",
      "userIdProvider": "JwtUserIdProvider (reads ClaimTypes.NameIdentifier)",
      "jwtFromQueryString": "access_token query param supported for WebSocket connections",
      "serverMethods": [
        {
          "name": "SendMessage",
          "params": ["Guid receiverId", "string content"],
          "description": "Validates sender from JWT, saves Message to DB (Type=Text), sends 'ReceiveMessage' event to receiver, 'MessageSent' event to caller"
        },
        {
          "name": "JoinPropertyRoom",
          "params": ["Guid propertyId"],
          "description": "Adds connection to SignalR group named propertyId.ToString(), broadcasts 'UserJoined' to group"
        },
        {
          "name": "LeavePropertyRoom",
          "params": ["Guid propertyId"],
          "description": "Removes connection from group, broadcasts 'UserLeft' to group"
        },
        {
          "name": "SendTypingIndicator",
          "params": ["Guid receiverId", "bool isTyping"],
          "description": "Sends 'UserTyping' event with ConnectionId and isTyping to receiver"
        },
        {
          "name": "MarkAsRead",
          "params": ["Guid messageId"],
          "description": "Sets message IsRead=true, ReadAt=now, UpdatedDate=now in DB, sends 'MessageRead' event to original sender"
        }
      ],
      "clientEvents": [
        "ReceiveMessage(Message savedMessage)",
        "MessageSent(Message savedMessage)",
        "UserJoined(string connectionId)",
        "UserLeft(string connectionId)",
        "UserTyping(string connectionId, bool isTyping)",
        "MessageRead(Guid messageId)"
      ]
    },

    "responseFormats": {
      "success_list": "PagedResult<T> { items, totalCount, page, pageSize, totalPages, hasNextPage, hasPreviousPage }",
      "success_single": "T (entity directly)",
      "created": "HTTP 201 Created with entity body",
      "notFound": "HTTP 404 with InnerException details",
      "badRequest_validation": "HTTP 400 with InvalidXxxException details (Xeptions library, DataList contains field errors)",
      "badRequest_dependency_validation": "HTTP 400 with inner exception (e.g. AlreadyExistsFavoriteException)",
      "unauthorized": "HTTP 401 (no body)",
      "forbidden": "HTTP 403 (no body)",
      "serverError": "HTTP 500 with InnerException details",
      "exceptionHierarchy": {
        "validation": "XxxValidationException wraps NullXxxException | InvalidXxxException",
        "dependencyValidation": "XxxDependencyValidationException wraps AlreadyExistsXxxException | NotFoundXxxException",
        "dependency": "XxxDependencyException wraps EF/DB exceptions",
        "service": "XxxServiceException wraps unexpected exceptions"
      }
    },

    "cors": {
      "developmentPolicy": "AllowAngular — origins: http://localhost:4200, https://localhost:4200; AllowAnyHeader; AllowAnyMethod; AllowCredentials",
      "productionPolicy": "Production — origins from AllowedOrigins config (appsettings.json: https://mulkchi.uz, https://www.mulkchi.uz); AllowAnyMethod; AllowAnyHeader; AllowCredentials"
    }
  },

  "frontend": {
    "framework": "Angular 19 (standalone components, no NgModules)",
    "rootDir": "mulkchi-frontend/src",

    "pages": [
      {
        "route": "/",
        "component": "HomeComponent",
        "file": "app/pages/home/home.component.ts",
        "auth": "public",
        "description": "Landing page — hero section, featured properties, search bar"
      },
      {
        "route": "/login",
        "component": "LoginComponent",
        "file": "app/pages/auth/login/login.component.ts",
        "auth": "public",
        "description": "Email+password login form with JWT storage"
      },
      {
        "route": "/register",
        "component": "RegisterComponent",
        "file": "app/pages/auth/register/register.component.ts",
        "auth": "public",
        "description": "Registration form (firstName, lastName, email, phone, password, preferredLanguage)"
      },
      {
        "route": "/properties",
        "component": "PropertyListComponent",
        "file": "app/pages/properties/property-list/property-list.component.ts",
        "auth": "public",
        "description": "Browseable property grid with filter bar (city, listingType, minPrice, maxPrice, bedrooms) and pagination"
      },
      {
        "route": "/properties/:id",
        "component": "PropertyDetailComponent",
        "file": "app/pages/properties/property-detail/property-detail.component.ts",
        "auth": "public",
        "description": "Property detail page"
      },
      {
        "route": "/dashboard",
        "component": "DashboardLayoutComponent",
        "file": "app/pages/dashboard/layout/dashboard-layout.component.ts",
        "auth": "authGuard",
        "children": [
          { "route": "/dashboard/overview",       "component": "DashboardOverviewComponent",  "file": "app/pages/dashboard/overview/dashboard-overview.component.ts" },
          { "route": "/dashboard/my-properties",  "component": "MyPropertiesComponent",       "file": "app/pages/dashboard/my-properties/my-properties.component.ts" },
          { "route": "/dashboard/requests",       "component": "RequestsComponent",           "file": "app/pages/dashboard/requests/requests.component.ts" },
          { "route": "/dashboard/payments",       "component": "PaymentsComponent",           "file": "app/pages/dashboard/payments/payments.component.ts" },
          { "route": "/dashboard/settings",       "component": "SettingsComponent",           "file": "app/pages/dashboard/settings/settings.component.ts" }
        ]
      },
      {
        "route": "**",
        "component": "NotFoundComponent",
        "file": "app/pages/not-found/not-found.component.ts",
        "auth": "public"
      }
    ],

    "services": [
      {
        "name": "AuthService",
        "file": "app/core/services/auth.service.ts",
        "apiCalls": [
          "POST /api/auth/login",
          "POST /api/auth/register",
          "POST /api/auth/refresh",
          "POST /api/auth/logout"
        ],
        "localStorage": ["mulkchi_token", "mulkchi_refresh_token", "mulkchi_user_id", "mulkchi_role"],
        "methods": ["login()", "register()", "logout()", "isLoggedIn()", "getRole()", "getUserId()"]
      },
      {
        "name": "PropertyService",
        "file": "app/core/services/property.service.ts",
        "apiCalls": [
          "GET /api/properties (with filter params)",
          "GET /api/properties/:id",
          "POST /api/properties",
          "PUT /api/properties",
          "DELETE /api/properties/:id"
        ]
      },
      {
        "name": "UserService",
        "file": "app/core/services/user.service.ts",
        "apiCalls": [
          "GET /api/users",
          "GET /api/users/:id",
          "PUT /api/users",
          "DELETE /api/users/:id"
        ]
      },
      {
        "name": "HomeRequestService",
        "file": "app/core/services/home-request.service.ts",
        "apiCalls": ["GET /api/homerequests", "GET /api/homerequests/:id", "POST /api/homerequests", "PUT /api/homerequests", "DELETE /api/homerequests/:id"]
      },
      {
        "name": "PaymentService",
        "file": "app/core/services/payment.service.ts",
        "apiCalls": ["GET /api/payments", "GET /api/payments/:id", "POST /api/payments", "PUT /api/payments", "DELETE /api/payments/:id"]
      },
      {
        "name": "ReviewService",
        "file": "app/core/services/review.service.ts",
        "apiCalls": ["GET /api/reviews", "GET /api/reviews/:id", "POST /api/reviews", "PUT /api/reviews", "DELETE /api/reviews/:id"]
      },
      {
        "name": "MessageService",
        "file": "app/core/services/message.service.ts",
        "apiCalls": ["GET /api/messages", "GET /api/messages/:id", "POST /api/messages", "PUT /api/messages", "DELETE /api/messages/:id"],
        "notes": "SignalR client connection to /hub defined but not wired in Angular (incomplete)"
      },
      {
        "name": "NotificationService",
        "file": "app/core/services/notification.service.ts",
        "apiCalls": ["GET /api/notifications", "GET /api/notifications/:id", "POST /api/notifications", "PUT /api/notifications", "DELETE /api/notifications/:id"]
      },
      {
        "name": "RentalContractService",
        "file": "app/core/services/rental-contract.service.ts",
        "apiCalls": ["GET /api/rentalcontracts", "GET /api/rentalcontracts/:id", "POST /api/rentalcontracts", "PUT /api/rentalcontracts", "DELETE /api/rentalcontracts/:id"]
      },
      {
        "name": "FavoriteService",
        "file": "app/core/services/favorite.service.ts",
        "apiCalls": ["GET /api/favorites", "GET /api/favorites/:id", "POST /api/favorites", "PUT /api/favorites", "DELETE /api/favorites/:id"]
      },
      {
        "name": "SavedSearchService",
        "file": "app/core/services/saved-search.service.ts",
        "apiCalls": ["GET /api/savedsearches", "GET /api/savedsearches/:id", "POST /api/savedsearches", "PUT /api/savedsearches", "DELETE /api/savedsearches/:id"]
      },
      {
        "name": "PropertyImageService",
        "file": "app/core/services/property-image.service.ts",
        "apiCalls": ["GET /api/propertyimages", "GET /api/propertyimages/:id", "POST /api/propertyimages", "PUT /api/propertyimages", "DELETE /api/propertyimages/:id"]
      },
      {
        "name": "PropertyViewService",
        "file": "app/core/services/property-view.service.ts",
        "apiCalls": ["GET /api/propertyviews", "GET /api/propertyviews/:id", "POST /api/propertyviews", "PUT /api/propertyviews", "DELETE /api/propertyviews/:id"]
      },
      {
        "name": "DiscountService",
        "file": "app/core/services/discount.service.ts",
        "apiCalls": ["GET /api/discounts", "GET /api/discounts/:id", "POST /api/discounts", "PUT /api/discounts", "DELETE /api/discounts/:id"]
      },
      {
        "name": "AiRecommendationService",
        "file": "app/core/services/ai-recommendation.service.ts",
        "apiCalls": ["GET /api/airecommendations", "GET /api/airecommendations/:id", "POST /api/airecommendations", "PUT /api/airecommendations", "DELETE /api/airecommendations/:id"]
      },
      {
        "name": "LanguageService",
        "file": "app/core/services/language.service.ts",
        "description": "Client-side language switching (uz/ru/en); no API calls; used by TranslatePipe"
      }
    ],

    "models": [
      {
        "file": "app/core/models/auth.models.ts",
        "interfaces": ["LoginRequest { email, password }", "RegisterRequest { firstName, lastName, email, phone, password, preferredLanguage }", "AuthResponse { token, refreshToken, expiresAt, userId, email, role }"]
      },
      {
        "file": "app/core/models/user.models.ts",
        "types": ["Gender = 'Male'|'Female'|'Other'", "UserRole = 'Guest'|'Host'|'Admin'", "HostBadge = 'None'|'SuperHost'|'PremiumHost'"],
        "interfaces": ["User (all fields matching backend User entity)", "PagedResult<T>"]
      },
      {
        "file": "app/core/models/property.models.ts",
        "types": ["ListingType", "PropertyType", "PropertyStatus", "PropertyCategory", "UzbekistanRegion (14 values)"],
        "interfaces": ["Property (all 70+ fields)", "PropertyFilter { city, region, minPrice, maxPrice, bedrooms, listingType, page, pageSize }"]
      },
      {
        "file": "app/core/models/home-request.models.ts",
        "interfaces": ["HomeRequest", "with RequestType and RequestStatus types"]
      },
      {
        "file": "app/core/models/payment.models.ts",
        "interfaces": ["Payment", "with PaymentType, PaymentStatus, PaymentMethod types"]
      },
      {
        "file": "app/core/models/review.models.ts",
        "interfaces": ["Review"]
      },
      {
        "file": "app/core/models/message.models.ts",
        "interfaces": ["Message", "with MessageType type"]
      },
      {
        "file": "app/core/models/notification.models.ts",
        "interfaces": ["Notification", "with NotificationType type"]
      },
      {
        "file": "app/core/models/rental-contract.models.ts",
        "interfaces": ["RentalContract", "with ContractStatus type"]
      },
      {
        "file": "app/core/models/favorite.models.ts",
        "interfaces": ["Favorite"]
      },
      {
        "file": "app/core/models/saved-search.models.ts",
        "interfaces": ["SavedSearch"]
      },
      {
        "file": "app/core/models/property-image.models.ts",
        "interfaces": ["PropertyImage"]
      },
      {
        "file": "app/core/models/property-view.models.ts",
        "interfaces": ["PropertyView"]
      },
      {
        "file": "app/core/models/discount.models.ts",
        "interfaces": ["Discount", "DiscountUsage", "with DiscountType, DiscountTarget types"]
      },
      {
        "file": "app/core/models/ai-recommendation.models.ts",
        "interfaces": ["AiRecommendation", "with AiRecommendationType type"]
      },
      {
        "file": "app/core/models/announcement.models.ts",
        "interfaces": ["Announcement", "with AnnouncementType, AnnouncementTarget types"]
      }
    ],

    "guards": [
      {
        "name": "authGuard",
        "file": "app/core/guards/auth.guard.ts",
        "type": "CanActivateFn",
        "logic": "Checks AuthService.isLoggedIn() (token in localStorage). Redirects to /login if false.",
        "usedOn": "/dashboard and all children"
      },
      {
        "name": "roleGuard",
        "file": "app/core/guards/role.guard.ts",
        "type": "CanActivateFn",
        "logic": "Reads route.data['role'], compares to AuthService.getRole(). Redirects to '/' if mismatch.",
        "usedOn": "Implemented but not applied to any route in app.routes.ts"
      }
    ],

    "interceptors": [
      {
        "name": "jwtInterceptor",
        "file": "app/core/interceptors/jwt.interceptor.ts",
        "logic": "Attaches 'Authorization: Bearer {token}' header from localStorage key 'mulkchi_token'. Skips /api/auth/login and /api/auth/register paths."
      },
      {
        "name": "errorInterceptor",
        "file": "app/core/interceptors/error.interceptor.ts",
        "logic": "401: clears mulkchi_token, mulkchi_refresh_token, mulkchi_user_id, mulkchi_role from localStorage and navigates to /login. 403: navigates to /. 5xx: console.error. Always rethrows."
      }
    ],

    "designSystem": {
      "framework": "Angular 19 standalone components",
      "uiLibrary": "Angular Material (MatSnackBar, MatSnackBarModule)",
      "styling": "Component-scoped SCSS (16 SCSS files)",
      "cssFramework": "none (no Tailwind, no Bootstrap)",
      "localization": "Custom TranslatePipe supporting uz (Uzbek), ru (Russian), en (English)",
      "formLabels": "Uzbek language used for form field labels",
      "icons": "Emoji-based icons (no icon font library)",
      "theme": {
        "note": "Custom SCSS — no centralized design tokens file discovered"
      }
    },

    "sharedComponents": [
      {
        "selector": "app-property-card",
        "file": "app/shared/components/property-card/property-card.component.ts",
        "inputs": ["@Input() property!: Property"],
        "outputs": [],
        "features": ["Emoji icon", "Verification badge", "Favorite toggle button", "Bedrooms/bathrooms/area display", "Price display (adapts to ListingType)", "Rating display", "Navigates to /properties/:id on click"]
      },
      {
        "selector": "app-navbar",
        "file": "app/shared/components/navbar/navbar.component.ts",
        "description": "Top navigation bar, shared across all pages"
      },
      {
        "selector": "app-footer",
        "file": "app/shared/components/footer/footer.component.ts",
        "description": "Page footer"
      },
      {
        "selector": "app-loading-spinner",
        "file": "app/shared/components/loading-spinner/loading-spinner.component.ts",
        "description": "Loading indicator used during async API calls"
      }
    ],

    "sharedPipes": [
      {
        "name": "TranslatePipe",
        "file": "app/shared/pipes/translate.pipe.ts",
        "description": "Translates UI string keys to uz/ru/en based on LanguageService current language"
      }
    ],

    "forms": [
      {
        "component": "LoginComponent",
        "formGroup": "loginForm",
        "fields": [
          { "name": "email",    "validators": ["required", "email"] },
          { "name": "password", "validators": ["required"] }
        ],
        "features": ["Password visibility toggle", "Error alert display", "Loading state", "Error message in Uzbek: 'To'g'ri email kiriting'"]
      },
      {
        "component": "RegisterComponent",
        "formGroup": "registerForm",
        "fields": [
          { "name": "firstName",          "validators": ["required"] },
          { "name": "lastName",           "validators": ["required"] },
          { "name": "email",              "validators": ["required", "email format"] },
          { "name": "phone",              "validators": ["required"] },
          { "name": "password",           "validators": ["required", "minLength(8)", "hasUppercase", "hasLowercase", "hasDigit"] },
          { "name": "preferredLanguage",  "validators": ["required"], "type": "select", "options": ["uz", "ru", "en"] }
        ],
        "features": ["Password visibility toggle", "Uzbek error messages"]
      },
      {
        "component": "PropertyListComponent",
        "formType": "inline query params (no FormBuilder)",
        "fields": [
          { "name": "filterCity",         "type": "text input" },
          { "name": "filterListingType",  "type": "select" },
          { "name": "filterMinPrice",     "type": "number input" },
          { "name": "filterMaxPrice",     "type": "number input" },
          { "name": "filterBedrooms",     "type": "number input" }
        ]
      }
    ],

    "environments": {
      "development": "mulkchi-frontend/src/environments/environment.ts — apiUrl: 'http://localhost:5000/api', hubUrl: 'http://localhost:5000/hub'",
      "production":  "mulkchi-frontend/src/environments/environment.prod.ts — production: true"
    },

    "workingFeatures": [
      "User authentication: login, register, logout, JWT storage in localStorage",
      "Role-based data (role stored in localStorage; JWT ClaimTypes.Role used on backend)",
      "HTTP JWT interceptor (auto-attaches Authorization header)",
      "HTTP error interceptor (401 redirect, 403 redirect, 5xx log)",
      "authGuard protecting /dashboard routes",
      "Public property browsing (GET /api/properties with server-side filters)",
      "Property detail page (GET /api/properties/:id)",
      "Pagination (PagedResult<T> backend + frontend PaginationParams)",
      "PropertyCard shared component (reusable across pages)",
      "Multi-language infrastructure (TranslatePipe, LanguageService, uz/ru/en)",
      "All 17 Angular services defined with full CRUD HTTP calls",
      "All 16 Angular model files defined (matching backend entities)",
      "All backend 17 controllers implemented with full CRUD",
      "All backend 17 foundation services with validation + exception handling",
      "Soft-delete pattern on all entities (DeletedDate + global EF query filters)",
      "SignalR ChatHub implemented (server-side): SendMessage, JoinPropertyRoom, LeavePropertyRoom, SendTypingIndicator, MarkAsRead",
      "JWT refresh token flow (issue, revoke, re-issue)",
      "Duplicate favorite guard"
    ],

    "incompleteFeatures": [
      "Dashboard pages (overview, my-properties, requests, payments, settings): skeleton shell components — no real data fetching or UI implementation",
      "SignalR Angular client: no @microsoft/signalr package integrated, no HubConnection created in any Angular service or component",
      "Property.ViewsCount / Property.FavoritesCount auto-increment: backend TODO comment — requires orchestration service pattern not yet implemented",
      "Property.AverageRating recalculation: no trigger on Review create/update",
      "Image upload: PropertyImage.Url is a plain string — no file upload endpoint, no multipart/form-data handling",
      "Payment gateway integration: Payme/Click/Uzcard gateways not integrated; PaymentUrl/ExternalTransactionId fields unused",
      "Discount application logic: no service-level validation of discount constraints (MaxUsageCount, StartsAt/ExpiresAt, IsActive); UsageCount not incremented",
      "Notification delivery: Notification entity stored but no push/email/in-app delivery mechanism",
      "Email service: no SMTP or email template service",
      "Review submission UI: property detail page lacks review creation form",
      "Rental contract creation/signing UI: no contract form or document upload",
      "Admin dashboard: no admin-specific UI for user management, property moderation, or analytics",
      "Map integration: Latitude/Longitude fields exist but no map component (no Google Maps/Mapbox)",
      "Saved search UI: save/load search form not implemented",
      "AI recommendations: AiRecommendation model is a shell; no ML backend, Metadata field is unstructured string",
      "Announcement display: no UI component renders announcements to users",
      "roleGuard: implemented but not applied to any route",
      "Token refresh: no automatic token refresh logic in Angular (no retry on 401 with refresh token call)",
      "Form validation: only login/register have implemented forms; property create/edit, booking request forms not implemented",
      "State management: no NgRx/Akita; component-level state only; potential subscription memory leaks",
      "JWT secret: appsettings.json contains placeholder 'CHANGE_ME_USE_ENVIRONMENT_VARIABLE_OR_USER_SECRETS' — must be replaced before production"
    ]
  },

  "gaps": [
    "BACKEND EXISTS, FRONTEND MISSING UI:",
    "  - MessagesController exists but Angular has no chat UI or SignalR connection",
    "  - NotificationsController exists but no notification bell/dropdown in navbar",
    "  - AnnouncementsController exists but no announcement banner/list in UI",
    "  - DiscountsController exists but no discount code input on booking flow",
    "  - DiscountUsagesController exists but discount application not triggered from frontend",
    "  - AiRecommendationsController exists but no recommendation widget in UI",
    "  - SavedSearchesController exists but no 'Save this search' button in property list",
    "  - PropertyImagesController exists but property create/edit forms are missing — no image management UI",
    "  - PropertyViewsController exists but views are never recorded from property detail page",
    "  - RentalContractsController exists but no contract creation/signing UI",
    "  - ReviewsController exists but no review submission form on property detail page",
    "  - HomeRequestsController exists but no booking request form on property detail page",
    "  - FavoritesController exists but favorites list/management page not in routes",
    "",
    "FRONTEND ROUTES MISSING (no pages defined for):",
    "  - /messages (chat page)",
    "  - /notifications",
    "  - /favorites",
    "  - /announcements",
    "  - /discounts",
    "  - /profile/:id (public user profile)",
    "  - /dashboard/messages",
    "  - /dashboard/notifications",
    "  - /dashboard/favorites",
    "  - /dashboard/contracts",
    "  - /dashboard/reviews",
    "",
    "BACKEND EXISTS BUT NO FRONTEND SERVICE CONSUMING IT:",
    "  - AnnouncementsController — no Angular AnnouncementService",
    "",
    "MISMATCH / ISSUES:",
    "  - Enums serialized as integers (numeric) by backend but Angular models use string union types — frontend must send numeric values (0, 1, 2...) not strings",
    "  - Property filter on GET /api/properties uses exact city match (==) but frontend likely expects partial/case-insensitive search",
    "  - No token auto-refresh in Angular: error interceptor clears session on 401 instead of attempting refresh first",
    "  - roleGuard implemented in Angular but not applied to any route; backend role checks exist on all admin/host endpoints",
    "  - JWT secret must be set via environment variable or user secrets before production deployment",
    "  - Property.ViewsCount and Property.FavoritesCount are never incremented (TODO on both controllers)"
  ]
}
```
