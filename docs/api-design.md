# Themis Web API
**NOTE:** `~` is used in this document as abbreviation to www.themis.com or any other domain name under which the web app will be hosted.

The API consists of two controllers:

- Home (Landing Page, About, Feedback, Contact, Impress, etc.)
- Plan (Creating, Editing and Showing Plans)

Moreover there will be two variants of that API:
- one for an MVC-razor-views client
- one for a react client

The MVC client can be reached under `~/`, while the react client (its static content) can be reached under `~/spa`. The react client will use mostly similar routes as the MVC client, but with a preceeding `/api` (e.g.: `www.themis/api/plan/asxwefr55v6e32$&$%`).


## Ideas and Concepts
### Privacy and Authorization via Hash-URIs
We try to implement a simple login free privacy and authorization concept. Thus created plans will only be reachable by a specific **access-hash** (`<acc-hash>`) that must allow so many combinations that finding a plan by chance is significantly small than 1%. They could look like this: `asxwefr55v6e32$&$%` and act like an ID for a plan.  
For every plan a second hash, the so called: **authorization-hash** will be created. It has the same form as the access-hash but is again randomly created and will be given to the creator of the plan. This second hash grants access to the EDIT and DELETE actions.

### Implications of the Hash-URIs
1. We use `plan` instead of the 100% RESTful correct plural `plans` for the plan controller, because users should not be able to view multiple plans. Their view should always be restricted to one plan at a time and there will also definitely not a list of plans.

2. The home page won't allow to navigate to the SHOW of a specific plan. It only provides a link to `~/plan/create`. The SHOW action can only be reached via direct link that the original creator of the plan will receive. He must share it with every plan participant.

## API Description (MVC)
| Route | Verb | Function |
|-------|------|----------|
| `~/`                     | GET         | Home Page|
|
| `~/plan/create`          | GET         | SHOW the plan-create form |
| `~/plan`                 | POST        | CREATEs a new plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `~/plan/success`. |
| `~/plan/success`         | GET         | SHOWs the two urls to the plan (one with `acc-hash` and one with `authhash`) |
| `~/plan/<acc~hash>`      | GET         | SHOWs the read-only plan. Might allow queries/filtering in future |
| `~/plan/<auth~hash>`     | GET         | SHOWs EDIT form for the plan. |
| `~/plan/<auth~hash>`     | PUT         | UPDATEs the plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `GET:~/plan/<acc~hash>`. |
| `~/plan/<auth~hash>`     | DELETE      | DELETEs the plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `GET:~/`. |


## API Description (SPA)

| Route | Verb | Function |
|-------|------|----------|
| `~/api/plan`             | AJAX~POST   | Same as MVC variant, but on submit success the two hashes are returned as server response to this method. |
| `~/api/plan/<acc~hash>`  | AJAX~GET    | GETs the read-only data for a plan as Json |
| `~/api/plan/<auth~hash>` | AJAX~PUT    | UPDATEs the plan. Data must be provided as Json in the request body. |
| `~/api/plan/<auth~hash>` | AJAX~DELETE | DELETEs the plan. Data must be provided as Json in the request body. |

## TO-DO: Data Description 