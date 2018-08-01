using System;
using System.Text;

namespace JobAd
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class JobApplication
    {
        // JpbApplication properties
        public Applicant Applicant { get; set; }
        public string AdditionalMotivation { get; set; }
        public IList<Skill> Skills { get; set; }
        public const string ContactPersonAt3 = "Steffen Jørgensen, 31 200 953";
        public const string FormattedVersionWithSyntaxHighlighting = "http://pastebin.com/jXuj19F2";

        /// <summary>
        /// Application constructor with parameters
        /// </summary>
        /// <param name="applicant">Applicant information</param>
        /// <param name="additionalMotivation">Application Motiviation letter</param>
        /// <param name="skills">Applicant skills</param>
        public JobApplication(Applicant applicant, string additionalMotivation, List<Skill> skills)
        {
            Applicant = applicant;
            AdditionalMotivation = additionalMotivation;
            Skills = skills;
        }

        /// <summary>
        /// Calculate the score for applicant and show his/her information
        /// </summary>
        /// <returns>return and string builder which contains the resulat and applicant information</returns>
        public string ApplicationAnalysis()
        {
            int score = JobApplicantAwesomenessLevel();
            StringBuilder sb = new StringBuilder(string.Format("{0} scorer {1} awesomeness point", this.Applicant.Name, score));
            if (!string.IsNullOrEmpty(AdditionalMotivation))
            {
                sb.Append(Environment.NewLine);
                sb.Append(string.Format("Udover ovenstående score har {0} også følgende motivation for ansættelsen: {1}", Applicant.Name, AdditionalMotivation));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Call to get applicant awesomeness level. The higher score the better. 
        /// </summary>
        /// <returns>An integer which show the awesome level for applicant</returns>
        private int JobApplicantAwesomenessLevel()
        {
            int applicantAwesomenessLevel = 0;

            bool isQualified = ApplicantHasAllRequiredSkills();
            if (isQualified)
            {
                applicantAwesomenessLevel = 10;
                applicantAwesomenessLevel += CountNiceToHaveSkills();
                applicantAwesomenessLevel += MetaSkillBonus();
            }
            return applicantAwesomenessLevel;
        }

        /// <summary>
        /// Check if the applicant has all required skills
        /// </summary>
        /// <returns>Return true if applicant meet all requirements, otherwise return false</returns>
        private bool ApplicantHasAllRequiredSkills()
        {
            List<Skill> requiredSkills = new List<Skill> {
                                                 new Skill() { SkillName = "ASP.NET", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Programming },
                                                 new Skill() { SkillName = "ASP.NET MVC", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Programming },
                                                 new Skill() { SkillName = "C#", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Programming },
                                                 new Skill() { SkillName = "Minimum 3 års erfaring", SkillLevel = SkillLevel.Pro, SkillCategory = SkillCategory.Meta },
                                                 new Skill() { SkillName = "Taler og skriver dansk", SkillLevel = SkillLevel.Pro, SkillCategory = SkillCategory.Meta },
                                                 new Skill() { SkillName = "Relevant uddannelse fra KU, ITU eller lignende", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                                 new Skill() { SkillName = "Trives med at have ansvar for egne projekter fra ide til implementering", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta }
                                             };
            foreach (Skill skill in requiredSkills)
            {
                bool hasSkill = (from relevantSkill in this.Skills
                                 where relevantSkill.SkillName == skill.SkillName
                                 && (relevantSkill.SkillLevel == SkillLevel.Average || relevantSkill.SkillLevel == SkillLevel.Pro)
                                 select relevantSkill).Any();
                if (hasSkill)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check the required skills and return a score for it
        /// </summary>
        /// <returns>An integer number which show applicant score</returns>
        private int CountNiceToHaveSkills()
        {
            List<Skill> niceToHaveSkills = new List<Skill>()
                                               {
                                                   new Skill() { SkillName = "Entity Framework", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "SQL", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "Unit testing", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "Dependency Injection", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "Agile development (Scrum)", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "HTML/CSS", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "jQuery", SkillLevel = SkillLevel.Beginner, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "Backend", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Programming },
                                                   new Skill() { SkillName = "Frontend", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Programming }
                                               };
            return (from skill in niceToHaveSkills
                    join applicantSkill in this.RelevantSkills(SkillCategory.Programming) on skill.SkillName equals applicantSkill.SkillName
                    select skill).Count();
        }

        /// <summary>
        /// Check the meta skills and return a bouns for it
        /// </summary>
        /// <returns>An integer number which show applicant bonus</returns>
        private int MetaSkillBonus()
        {
            List<Skill> metaSkills = new List<Skill>()
                                         {
                                             new Skill() { SkillName = "Trives i et ungt og dynamisk miljø", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Nysgerrig og lærenem", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Nyder at arbejde tæt sammen med andre udviklere og kravstillere", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Ønsker at arbejde i et lille .NET team med senior and junior developers", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Har humor og masser af godt humør", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Foretrækker lækker mad fra en kantine fremfor kedelige madpakker", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta },
                                             new Skill() { SkillName = "Ser frem til hyggelige sociale arrangementer med kollegaerne", SkillLevel = SkillLevel.Average, SkillCategory = SkillCategory.Meta }
                                         };
            return (from skill in metaSkills
                    join applicantSkill in this.RelevantSkills(SkillCategory.Meta).AsQueryable() on skill.SkillName equals applicantSkill.SkillName
                    select skill).Count();
        }

        /// <summary>
        /// Join the skills and skills category and return 
        /// </summary>
        /// <param name="skillCategory"></param>
        /// <returns></returns>
        private IEnumerable<Skill> RelevantSkills(SkillCategory skillCategory)
        {
            return (from skill in this.Skills
                    where skill.SkillCategory == skillCategory
                    select skill);
        }

        /// <summary>
        /// Print out the CV
        /// </summary>
        public void ShowCV()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine(" ");
            Console.WriteLine(String.Format("     Full Name: {0}", Applicant.Name));
            Console.WriteLine(String.Format("     Email Address: {0}", Applicant.Email));
            Console.WriteLine(String.Format("     Contact Number: {0}", Applicant.Phonenumber));
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================");
            Console.WriteLine(" Motivation:");
            Console.WriteLine(ShowMotivation(60, AdditionalMotivation));
            Console.WriteLine("==============================================================");
            Console.WriteLine(" Skills: ");
            foreach (var skill in Skills)
            {
                Console.WriteLine(String.Format(" Skill: {0} -> Level: {1} => Category: {2}", skill.SkillName, skill.SkillLevel, skill.SkillCategory));
            }
            Console.WriteLine("==============================================================");

        }

        /// <summary>
        /// Show the long motivation in the limited number of columns
        /// </summary>
        /// <param name="limitsize">Maximum size for the columns</param>
        /// <param name="text">The text which must show in the application</param>
        /// <returns>And string bulder which conatins the aligned text</returns>
        private StringBuilder ShowMotivation(int limitsize, string text)
        {
            string[] words = text.Split(' ');

            StringBuilder newSentence = new StringBuilder();


            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > limitsize)
                {
                    newSentence.AppendLine(line);
                    line = "";
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0)
                newSentence.AppendLine(line);

            return newSentence;
        }
    }

    /// <summary>
    /// Applicant class which contains some properties for applicant,
    /// such as name, email and phone number
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// Applicant constructor with parameters
        /// </summary>
        public Applicant(string _name, string _email, string _phonenumber)
        {
            Name = _name;
            Email = _email;
            Phonenumber = _phonenumber;
        }

        // Applicant's properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
    }

    /// <summary>
    /// Skill class which contains name of skill, category and level of skill
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Skill constructor without parameters
        /// </summary>
        public Skill()
        {

        }

        /// <summary>
        /// Skill constructor with parameters
        /// </summary>
        public Skill(string _skillname, SkillCategory _skillcategory, SkillLevel _skilllevel)
        {
            SkillName = _skillname;
            SkillCategory = _skillcategory;
            SkillLevel = _skilllevel;
        }

        // Skill's properties
        public string SkillName { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public SkillLevel SkillLevel { get; set; }
    }

    /// <summary>
    /// List of all levels for skills
    /// </summary>
    public enum SkillLevel
    {
        Beginner,
        Average,
        Pro
    }

    /// <summary>
    /// List of all skill categories
    /// </summary>
    public enum SkillCategory
    {
        Programming,
        Meta
    }
}