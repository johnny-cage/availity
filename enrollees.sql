/* 
Write a SQL query that wil show the total value of all orders each customer has placed in the past six months. Any customer without any orders should show a $0 value.

*/
select c.firstname, c.lastname, COALESCE(SUM(ol.cost * ol.quantity), 0) as total
from customers c
left join orders o
on c.customerid = o.customer_id and o.orderdate >= CURRENT_TIMESTAMP - INTERVAL '6 months'
left join orderlines ol
on o.orderid = ol.order_id
group by c.customerid;

/*
Write a SQL query that will produce a reverse-sorted list (alphabetically by name) of customers (first and last names) whose last name begins with the letter ‘S.’
*/
select * from customers
where lastname like 'S%'
order by lastname desc,firstname desc

/*
Amend the query from the previous question to only show those customers who have a total order value of more than $100 and less than $500 in the past six months
*/
select c.firstname, c.lastname, SUM(ol.cost * ol.quantity) as total
from customers c
left join orders o
on c.customerid = o.customer_id and o.orderdate >= CURRENT_TIMESTAMP - INTERVAL '6 months'
left join orderlines ol
on o.orderid = ol.order_id
group by c.customerid
having SUM(ol.cost * ol.quantity) between 100 and 500
