interface IStatuses {
  UserId: number;
  LastName: string;
  FirstName: string;
  Phone: string;
  Email: string;
  StatusDescription: string;

  StartHourOnMondayHour: string;
  StartHourOnTuesdayHour: string;
  StartHourOnWednesdayHour: string;
  StartHourOnThursdayHour: string;
  StartHourOnFridayHour: string;
  Project: IProjectShort;
}
