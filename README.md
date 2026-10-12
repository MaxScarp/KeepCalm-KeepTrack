# KeepCalm&KeepTrack

A small Windows app I wrote to track the time I spend on my personal projects. Each project has its tasks, each task has its time frames: press Start when you begin, Stop when you are done, and the app sums it all up.

## What it does

- Projects and tasks are shown as buttons, so the whole thing works with a couple of clicks.
- A task opens a Time Frame window with a Start/Stop button. Every start and stop is saved as a time frame with its duration.
- Total Time shows, for each project, how many tasks it has, when the work started, when it last stopped and the hours spent.

## How it is built

- `KeepCalm_KeepTrack.Client`: Windows Forms on .NET 8. One main form plus small forms for adding a project, adding a task, the time frame and the totals.
- `KeepCalm_KeepTrack.Database`: Entity Framework Core 8 with a DbContext factory, entity configurations and migrations. Three entities: Project, Task, TimeFrame.
- SQL Server as the database. The connection string is in `App.config`.

## Running it

1. Set the connection string in `KeepCalm_KeepTrack.Database/App.config`.
2. Apply the migration from the Database project (`dotnet ef database update`).
3. Start `KeepCalm_KeepTrack.Client`.

A ClickOnce build is in the `Builds` folder.
