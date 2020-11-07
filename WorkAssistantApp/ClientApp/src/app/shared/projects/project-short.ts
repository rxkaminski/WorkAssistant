export class ProjectShort implements IProjectShort {
  Id: number;
  Number: string;
  Title: string;

  constructor(projectShort: IProjectShort) {
    this.Id = projectShort.Id;
    this.Number = projectShort.Number;
    this.Title = projectShort.Title;
  }

  isEqual(other: ProjectShort): boolean {
    return this.Id == other.Id;
  }

  public toString(): string {
    return this.Number + ": " + this.Title;
  }
}
