export class StartHour implements IStartHour {
  Id: number;
  Hour: string;

  constructor(projectShort: IStartHour) {
    this.Id = projectShort.Id;
    this.Hour = projectShort.Hour;
  }

  isEqual(other: StartHour): boolean {
    return this.Id == other.Id;
  }

  public toString(): string {
    return this.Hour;
  }
}
