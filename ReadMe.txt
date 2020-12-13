Since his amazing commercials, Saul Goodman, the well-known attorney has so many new
clients that he cannot handle the billing, therefore he needs some fancy computer software to do it.
The data of the clients and their cases are stored in a text file. A line in this file consists of the title of the current
case (e.g. money laundering, the name of the client (e.g. Mr. Heisenberg), the short descriptions and time duration
of previous meetings (e.g. consultancy;15 for a 15 minute long general discussion) and the dificulty level of the case.

1. Class Meeting 
   Represents a meeting session.
   - description: string type, the short details of the session
   - time: integer, the time duration of the session in minutes
   These data should be accessible via read-only properties. The constructor takes the description and the time
   duration of the meeting and sets the corresponding data fields..

2. Class Case 
   Represents a case managed by Saul.
   - clientName: string type, the name of the client related to case instance
   - difficulty: custom dened enum (DifficultyLevels), the risk-level of the case. Possible values are
   easypeasy, average, nightmare and ultramegahard.
   The data of previous meetings related to this case are stored in the array meetings. Fields are accessible through
   read-only properties. Member functions of the class:
   - Store(Meeting): private method, it places the Meeting instance passed into the rst empty element of
   meetings
   - ProcessData(string[], string[]): based on the string arrays (descriptions and times) passed as arguments,
   it first initializes the array meetings, then fills with Meeting instances by calling Store(). We can assume
   that the arrays in the argument list have the same size.
   - LongSessions(): if a meeting takes more than 30 minutes, it is called a long session. This method collects
   such meetings and returns the resulting array that should have no empty (null) elements in it.
   - Billing(): calculates and returns the current bill of the case based on meetings. A single minute of a
   meeting makes $1 for average cases. Multipliers for other dificulty levels are 0:5, 10 and 100, respectively.
