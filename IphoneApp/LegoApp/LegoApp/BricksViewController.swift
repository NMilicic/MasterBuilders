//
//  BricksViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 28/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//
import UIKit
import Alamofire
import SVProgressHUD
import Unbox

class BricksViewController: UIViewController, UITableViewDataSource,UITableViewDelegate {

    
    
    @IBOutlet weak var tableView: UITableView!
    
    var myB: [MyBrick] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        print("otvoreno")
        getBricksList()
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func getBricksList() {
        
        
        SVProgressHUD.show()
        
        Alamofire.request("http://mylego.local/api/PartApi/GetAll?take=20",headers: nil).responseJSON { (response:DataResponse<Any>) in
            switch response.result {
            case .success:
                SVProgressHUD.showSuccess(withStatus: "")
                if let data = response.data {
                    do {
                        var myB=[MyBrick]()
                        myB = try unbox(data: data)
                        print("\(myB)")
                        self.myB = myB
                        self.tableView.reloadData()
                    } catch _ {
                        print("krepalo")                    }
                } else {
                    // javit korisniku da je nesto crklo, i da proba poslije
                }
                
            case .failure(let error):
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
        }
    }
    func numberOfSectionsInTableView(tableView: UITableView) -> Int {
        return 1
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        print("\(myB.count)")
        return myB.count
    }
    
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        print("tu");
        let cell = self.tableView.dequeueReusableCell(withIdentifier: "cell") as! CustomBricksCell
        print("ucitavam kockice");
        
        cell.id.text = String(myB[indexPath.row].Id)
        cell.name.text = myB[indexPath.row].Ime
        cell.category.text = myB[indexPath.row].Kategorija
     
        
        if myB[indexPath.row].Slika != "null" {
            print("slika nije null")
            //let url: NSURL = NSURL(string: myB[indexPath.row].Slika)!
            
            //let url: NSURL = NSURL(string: "http://legoboje.byethost33.com/web/3710.png")!
            // TODO add reachability pod and connection check on app start
            ///NE RADIIIIIIII
            /*
            let data : NSData = NSData(contentsOf: url as URL)!
            cell.photoB?.image = UIImage(data: data as Data)*/
            let url: NSURL = NSURL(string: myB[indexPath.row].Slika)!
            //let url = NSURL(string:"http://legoboje.pe.hu/NULL.png")
            let data = NSData(contentsOf:url as URL)
             
            // It is the best way to manage nil issue.
            if (data?.length)! > 0 {
                cell.photoB?.image = UIImage(data:data as! Data)
            } else {
                // In this when data is nil or empty then we can assign a placeholder image
               //cell.photoB?.image = UIImage(named: "placeholder.png")
            }
        }
        return cell
    }

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
