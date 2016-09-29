 --1.Give the names of employees, whose salaries are greater than their immediate managers’:

 SELECT e.name FROM Employee e INNER JOIN Employee m ON e.manager_id = m.id 
 WHERE e.salary > m.salary


 --2.What is the average salary of employees who do not manage anyone? 
 --In the sample above, that would be John, Mike, Joe and Dan, since they do not have anyone reporting to them.
 SELECT AVG(e.salary) FROM Employee e 
 WHERE e.manager_id IS NOT NULL
