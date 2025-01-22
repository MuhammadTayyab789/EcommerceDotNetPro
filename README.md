SELECT 
   @IsSalaried = (CASE WHEN ku.CRP_Type = 4 THEN 'Salaried' ELSE 'Housewives' END), 
   @FundProviderName = ISNULL(FUNDS_PROV_NAME, ''),
   @IsRetryAllowedForKyc =  case when  (ISNULL(ku.RetryCount, 0) < 3) THEN '1' ELSE '0' END
   FROM dbo.KycUpdate ku WITH (NOLOCK)
   WHERE CustomerID_Number = @CNIC
   AND ISNULL(IsKycUpdated, 0) = 0
   AND DATEDIFF(DAY, ISNULL(ku.ModifiedAt , DATEADD(DAY, -5, GETDATE())), GETDATE()) > 3
   ;

   UPDATE dbo.KycUpdate SET RetryCount  = ISNULL(RetryCount, 0) + 1 , ModifiedAt = GETDATE()
   WHERE CustomerID_Number = @CNIC
   AND ISNULL(IsKycUpdated, 0) = 0
