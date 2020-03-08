SELECT
    O."Id"
FROM "Orders" O
    INNER JOIN "Customers" C
            ON O."CustomerId" = C."Id"
    LEFT JOIN "Accounts" A
           ON C."AccountId" = A."Id"
WHERE A."Username" = @username
