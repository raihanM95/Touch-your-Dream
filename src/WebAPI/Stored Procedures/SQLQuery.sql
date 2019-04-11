-- Store Procedure --

CREATE PROCEDURE addAdvisorInfo
(
	@Name nvarchar(50),
	@Email nvarchar(50)
)
AS
BEGIN
	INSERT INTO Advisor (Name, Email)
	VALUES (@Name, @Email)
END


CREATE PROCEDURE addStudentInfo
(
	@Name nvarchar(50),
	@Email nvarchar(50)
)
AS
BEGIN
	INSERT INTO Student (Name, Email)
	VALUES (@Name, @Email)
END


CREATE PROCEDURE getAdvisorList
AS
BEGIN
	SELECT*
	FROM Advisor
END


CREATE PROCEDURE getStudentList
AS
BEGIN
	SELECT*
	FROM Student
END


CREATE PROCEDURE updateAdvisorInfo
(
	@AdvId int,
	@Name nvarchar(50),
	@Gender nvarchar(10),
	@Email nvarchar(50),
	@Phone nvarchar(11),
	@VarsityName nvarchar(50),
	@DeptName nvarchar(50),
	@Designation nvarchar(20),
	@Address nvarchar(150),
	@Image nvarchar(MAX)
)
AS
BEGIN
	UPDATE Advisor
	SET Name=@Name,
	Gender=@Gender,
	Email=@Email,
	Phone=@Phone,
	VarsityName=@VarsityName,
	DeptName=@DeptName,
	Designation=@Designation,
	Address=@Address,
	Image=@Image
	WHERE Id=@AdvId
END


CREATE PROCEDURE updateStudentInfo
(
	@StdntId int,
	@Name nvarchar(50),
	@DateOfBirth date,
	@Gender nvarchar(10),
	@Email nvarchar(50),
	@Phone nvarchar(11),
	@VarsityName nvarchar(50),
	@DeptName nvarchar(50),
	@Address nvarchar(150),
	@Image nvarchar(MAX)
)
AS
BEGIN
	UPDATE Student
	SET Name=@Name,
	DateOfBirth=@DateOfBirth,
	Gender=@Gender,
	Email=@Email,
	Phone=@Phone,
	VarsityName=@VarsityName,
	DeptName=@DeptName,
	Address=@Address,
	Image=@Image
	WHERE Id=@StdntId
END


CREATE PROCEDURE removeAdvisor
(
	@AdvId int
)
AS
BEGIN
	DELETE FROM Advisor WHERE Id=@AdvId
END


CREATE PROCEDURE removeStudent
(
	@StdntId int
)
AS
BEGIN
	DELETE FROM Student WHERE Id=@StdntId
END


CREATE PROCEDURE entrySubjectInfo
(
	@Varsity nvarchar(50),
	@Subject nvarchar(50),
	@Job int,
	@Year nvarchar(5)
)
AS
BEGIN
	INSERT INTO Subject (Varsity, Subject, Job, Year)
	VALUES (@Varsity, @Subject, @Job, @Year)
END


CREATE PROCEDURE getSubjectInfoList
AS
BEGIN
	SELECT*
	FROM Subject
END


CREATE PROCEDURE updateSubjectInfo
(
	@SubId int,
	@Varsity nvarchar(50),
	@Subject nvarchar(50),
	@Job int,
	@Year nvarchar(5)
)
AS
BEGIN
	UPDATE Subject
	SET Varsity=@Varsity,
	Subject=@Subject,
	Job=@Job,
	Year=@Year
	WHERE Id=@SubId
END


CREATE PROCEDURE removeSubjectInfo
(
	@SubId int
)
AS
BEGIN
	DELETE FROM Subject WHERE Id=@SubId
END


CREATE PROCEDURE entryJobWiseSkill
(
	@JobName nvarchar(50),
	@SkillName nvarchar(10),
	@Value int
)
AS
BEGIN
	INSERT INTO Skill (JobName, SkillName, Value)
	VALUES (@JobName, @SkillName, @Value)
END


CREATE PROCEDURE updateJobWiseSkill
(
	@SkillId int,
	@JobName nvarchar(50),
	@SkillName nvarchar(10),
	@Value int
)
AS
BEGIN
	UPDATE Skill
	SET JobName=@JobName,
	SkillName=@SkillName,
	Value=@Value
	WHERE Id=@SkillId
END


CREATE PROCEDURE removeSkill
(
	@SkillId int
)
AS
BEGIN
	DELETE FROM Skill WHERE Id=@SkillId
END

CREATE PROCEDURE entryJobWiseCGPA
(
	@JobName nvarchar(50),
	@Semester nvarchar(10),
	@CGPA int
)
AS
BEGIN
	INSERT INTO CGPA (JobName, Semester, CGPA)
	VALUES (@JobName, @Semester, @CGPA)
END


CREATE PROCEDURE updateJobWiseCGPA
(
	@CGPAId int,
	@JobName nvarchar(50),
	@Semester nvarchar(10),
	@CGPA int
)
AS
BEGIN
	UPDATE CGPA
	SET JobName=@JobName,
	Semester=@Semester,
	CGPA=@CGPA
	WHERE Id=@CGPAId
END


CREATE PROCEDURE removeCGPA
(
	@CGPAId int
)
AS
BEGIN
	DELETE FROM CGPA WHERE Id=@CGPAId
END


CREATE PROCEDURE entrySGuideline
(
	@Scholarship nvarchar(50),
	@Step nvarchar(10),
	@ToDo nvarchar(20)
)
AS
BEGIN
	INSERT INTO Scholarship (Scholarship, Step, ToDo)
	VALUES (@Scholarship, @Step, @ToDo)
END


CREATE PROCEDURE updateSGuideline
(
	@SId int,
	@Scholarship nvarchar(50),
	@Step nvarchar(10),
	@ToDo nvarchar(20)
)
AS
BEGIN
	UPDATE Scholarship
	SET Scholarship=@Scholarship,
	Step=@Step,
	ToDo=@ToDo
	WHERE Id=@SId
END


CREATE PROCEDURE removeScholarship
(
	@SId int
)
AS
BEGIN
	DELETE FROM Scholarship WHERE Id=@SId
END

CREATE PROCEDURE publishRPaper
(
	@Title nvarchar(50),
	@FileName nvarchar(60),
	@FilePath nvarchar(MAX),
	@Date date
)
AS
BEGIN
	INSERT INTO ResearchPaper (Title, FileName, FilePath, Date)
	VALUES (@Title, @FileName, @FilePath, @Date)
END


CREATE PROCEDURE getResearchPaperList
AS
BEGIN
	SELECT*
	FROM ResearchPaper
END


CREATE PROCEDURE deleteRPaper
(
	@RPId int
)
AS
BEGIN
	DELETE FROM ResearchPaper WHERE Id=@RPId
END