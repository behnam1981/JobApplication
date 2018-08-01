using JobAd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication_Behrouz_Hosseini
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicant = new Applicant("Behrouz Hosseini", "behrouz.hosseini.81@gmail.com", "+45 52 78 67 15");

            var motivation = "Briefly, I graduated in Master of Information Management and Bachelor of Computer Science." +
                " I have been working as a software developer for over ten years and my current position is software developer " +
                "with .NET and .NET Core for different project like web application or interfaces for robots. You can see my " +
                "web application in https://www.robots.inhancer.dk and other project run on the ROS (Robot Operating System). " +
                "My previous experience focused on C#, .NET, .NET Core for Web and Desktop Application through visual studio. " +
                "I have the ability to adapt to any type of environment and I can learn the rules and procedures of your company " +
                "in a fast and efficient manner. I am team oriented and get along with others when working in a group setting. " +
                "I also have the ability to work independently as a freelancer and in a team as a SCRUM team. I have excellent " +
                "problem-solving abilities and time management skills with the ability to stay organized and I am always dependable.";

            var skills = new List<Skill>() {
                new Skill("ASP.NET" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("ASP.NET MVC" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("C#" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("Unit testing" , SkillCategory.Programming, SkillLevel.Average),
                new Skill("Entity Framework" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("SQL" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("jQuery" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("Backend" , SkillCategory.Programming, SkillLevel.Pro),
                new Skill("Dependency Injection" , SkillCategory.Programming, SkillLevel.Average),
                new Skill("Agile development (Scrum)" , SkillCategory.Programming, SkillLevel.Pro),

                new Skill("Frontend" , SkillCategory.Programming, SkillLevel.Average),
                new Skill("HTML/CSS" , SkillCategory.Programming, SkillLevel.Average),
                new Skill("Javascript" , SkillCategory.Programming, SkillLevel.Pro),

                new Skill("Minimum 3 års erfaring", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Taler og skriver dansk", SkillCategory.Meta, SkillLevel.Average),
                new Skill("Relevant uddannelse fra KU, ITU eller lignende", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Trives med at have ansvar for egne projekter fra ide til implementering", SkillCategory.Meta, SkillLevel.Pro),

                new Skill("Har humor og masser af godt humør", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Trives i et ungt og dynamisk miljø", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Nyder at arbejde tæt sammen med andre udviklere og kravstillere", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Ønsker at arbejde i et lille .NET team med senior and junior developers", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Nysgerrig og lærenem", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Foretrækker lækker mad fra en kantine fremfor kedelige madpakker", SkillCategory.Meta, SkillLevel.Pro),
                new Skill("Ser frem til hyggelige sociale arrangementer med kollegaerne", SkillCategory.Meta, SkillLevel.Pro),
            };

            var application = new JobApplication(applicant, motivation, skills) ;
            application.ShowCV();
            Console.Write(application.ApplicationAnalysis());
            Console.Read();
        }
    }
}
